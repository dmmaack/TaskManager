using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.UnitOfWork;
using TaskManager.Infra.Context;

namespace TaskManager.Infra.Repositories;

public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
{
    public TaskRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}