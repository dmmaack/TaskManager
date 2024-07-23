using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    void UpdateUser(UserEntity user);
    Task<IEnumerable<UserEntity>> SearchUsers(string specification);
}