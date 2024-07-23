using System.Linq.Expressions;
using Microsoft.Identity.Client;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Context;

namespace TaskManager.Infra.Repositories;

public class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
{
    public ProjectRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }

    public async Task<IEnumerable<ProjectEntity>> GetAllByUserIdAsync(long userId)
    {
        Expression<Func<ProjectEntity, bool>> predicate = 
            predicate => predicate.UserId.Equals(userId);
        
        return await this.GetAsync(predicate);
    }
}