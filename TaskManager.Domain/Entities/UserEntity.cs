using System.Linq.Expressions;
using TaskManager.Domain.Validators;

namespace TaskManager.Domain.Entities;

public class UserEntity : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public DateTime RegisterDate { get; private set; }
    public bool? IsActive { get; private set; } = true;

    public IEnumerable<ProjectEntity> Projects { get; set; }

    public UserEntity() { }

    public UserEntity(int id, string name, string email, string userName, string password,
                      DateTime registerDate, bool isActive)
                      : base(id)
    {
        Name = name;
        Email = email;
        UserName = userName;
        Password = password;
        RegisterDate = registerDate;
        IsActive = isActive;

        Projects = new HashSet<ProjectEntity>();
    }

    public void ValidateUser()
    {
        this.Validate(new UserEntityValidator(), this);
    }

    public void SetIsActive(bool isActive) => this.IsActive = isActive;

    public void SetRegisterDate(DateTime registerDate) => this.RegisterDate = registerDate;

    public Expression<Func<UserEntity, bool?>> IsActiveSpecification() => x => x.IsActive;

    public Expression<Func<UserEntity,bool>> SearchTermSpecification(string key) => x => 
        key.IndexOf(x.Name, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
        key.IndexOf(x.UserName, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
        key.IndexOf(x.Email, StringComparison.CurrentCultureIgnoreCase) >= 0;
}