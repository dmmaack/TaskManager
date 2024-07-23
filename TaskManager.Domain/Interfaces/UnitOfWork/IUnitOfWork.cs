using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IProjectRepository ProjectRepository { get; }
    ITaskRepository TaskRepository { get; }
    
    Task CommitAsync();
    void Dispose();
}