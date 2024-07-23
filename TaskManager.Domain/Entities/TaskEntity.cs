using TaskManager.Domain.Validators;

namespace TaskManager.Domain.Entities;

public class TaskEntity : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime RegisterDate { get; private set; } = DateTime.UtcNow;
    public int Status { get; private set; } = 1;
    public int Priority { get; private set; } = 1;

    public long ProjectId { get; private set; }
    public virtual ProjectEntity Project { get; private set; }

    public TaskEntity() { }

    public TaskEntity(long id, string title, string description, DateTime startDate, DateTime endDate,
                      DateTime registerDate, int status, long projectId)
                      : base(id)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        RegisterDate = registerDate;
        Status = status;
        ProjectId = projectId;

        ValidateTask();
    }

    public void SetEndDate(DateTime endDate)
    {
        EndDate = endDate;
        ValidateTask();
    }

    public void SetStartDate(DateTime startDate)
    {
        StartDate = startDate;
        ValidateTask();
    }

    public void SetProject(long projectId)
    {
        ProjectId = projectId;
        ValidateTask();
    }


    public void ValidateTask()
    {
        this.Validate(new TaskEntityValodator(), this);
    }
}