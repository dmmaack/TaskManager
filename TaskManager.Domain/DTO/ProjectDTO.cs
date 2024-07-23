namespace TaskManager.Domain.DTO;

public class ProjectDTO
{
    public ProjectDTO()
    {
    }

    public ProjectDTO(long id, string projectName, DateTime registerDate, DateTime endDate, bool isActive, long userId, DateTime startDate)
    {
        Id = id;
        ProjectName = projectName;
        RegisterDate = registerDate;
        EndDate = endDate;
        IsActive = isActive;
        UserId = userId;
        StartDate = startDate;
    }

    public long Id { get; private set; }
    public string ProjectName { get; private set; }
    public DateTime RegisterDate { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; }
    public long UserId { get; private set; }
}