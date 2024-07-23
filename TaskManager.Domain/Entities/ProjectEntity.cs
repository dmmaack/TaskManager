using System.Data.Common;
using TaskManager.Domain.Validators;

namespace TaskManager.Domain.Entities;

public class ProjectEntity : BaseEntity
{
    public string ProjectName { get; private set; }
    public DateTime RegisterDate { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; } = true;

    public long UserId { get; private set; }
    public virtual UserEntity User { get; private set; }

    public IEnumerable<TaskEntity> Tasks { get; set; }

    public ProjectEntity() { }

    public ProjectEntity(long id, string projectName, DateTime registerDate, bool isActive,
                         long userId, DateTime endDate, DateTime startDate)
                         : base(id)
    {
        ProjectName = projectName;
        RegisterDate = registerDate;
        IsActive = isActive;
        UserId = userId;
        EndDate = endDate;
        StartDate = startDate;

        Tasks = new HashSet<TaskEntity>();

        ValidateProject();
    }

    public void SetEndDate(DateTime endDate) => EndDate = endDate;

    public void SetUser(long userId) => UserId = userId;

    public void SetIsActive(bool isActive) => IsActive = isActive;
    
    public void SetRegisterDate(DateTime registerDate) => RegisterDate = registerDate;

    public void ValidateProject()
    {
        this.Validate(new ProjectEntityValodator(), this);
    }
}