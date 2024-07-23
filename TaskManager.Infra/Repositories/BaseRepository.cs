using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.UnitOfWork;
using TaskManager.Infra.Context;

namespace TaskManager.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{

    public readonly AppDbContext _appDbContext;

    public BaseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public virtual async Task<T> CreateAsync(T obj)
    {
        await _appDbContext.AddAsync(obj);
        return obj;
    }

    public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true) 
            => asNoTracking
            ? await BuildQuery(expression)
                   .AsNoTracking()
                   .ToListAsync()
            : await BuildQuery(expression)
                   .ToListAsync();

    public virtual async Task<T> GetByIdAsync(long id, bool asNoTracking = true)
    {
        Expression<Func<T, bool>> expression = expression => expression.Id.Equals(id);

        return await BuildQuery(expression)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var obj = _appDbContext.Set<T>().AsNoTracking();
        return await obj.ToListAsync();
    }

    private IQueryable<T> BuildQuery(Expression<Func<T, bool>> expression)
            => _appDbContext.Set<T>().Where(expression);
}