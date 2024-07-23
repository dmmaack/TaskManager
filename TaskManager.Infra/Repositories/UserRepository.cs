using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Identity.Client;
using TaskManager.Core.Expressions;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Interfaces.UnitOfWork;
using TaskManager.Infra.Context;

namespace TaskManager.Infra.Repositories;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }

    public void UpdateUser(UserEntity user)
    {
        this._appDbContext.Users.Update(user);
    }

    public async Task<IEnumerable<UserEntity>> SearchUsers(string specification)
    {
        Expression<Func<UserEntity, bool>> predicate = 
            predicate => predicate.UserName.Contains(specification) ||
                         predicate.Name.Contains(specification) ||
                         predicate.Email.Contains(specification);        

        return await this.GetAsync(predicate);
    }
}