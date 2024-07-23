using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.UnitOfWork;
using TaskManager.Infra.Context;

namespace TaskManager.Infra.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IUserRepository _userRepository;
    private IProjectRepository _projectRepository;
    private ITaskRepository _taskRepository;

    private readonly AppDbContext _appDbContext;

    public IUserRepository UserRepository
    {
        get
        {
            return _userRepository = _userRepository ??= new UserRepository(appDbContext: _appDbContext);
        }
    }

    public IProjectRepository ProjectRepository
    {
        get
        {
            return _projectRepository = _projectRepository ??= new ProjectRepository(appDbContext: _appDbContext);
        }
    }

    public ITaskRepository TaskRepository
    {
        get
        {
            return _taskRepository = _taskRepository ??= new TaskRepository(appDbContext: _appDbContext);
        }
    }

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CommitAsync() => await _appDbContext.SaveChangesAsync();

    public void Rollback() => Dispose();

    public void Dispose()
    {
        _appDbContext.DisposeAsync();
    }
}