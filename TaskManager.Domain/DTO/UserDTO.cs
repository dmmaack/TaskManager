using System.Text.Json.Serialization;

namespace TaskManager.Domain.DTO;

public class UserDTO
{
    public UserDTO(string name, string email, string userName, string password, DateTime registerDate, bool isActive, long id)
    {
        Name = name;
        Email = email;
        UserName = userName;
        Password = password;
        RegisterDate = registerDate;
        IsActive = isActive;
        Id = id;
    }
    public UserDTO() { }

    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    public DateTime RegisterDate { get; private set; }
    public bool IsActive { get; private set; }

    [JsonIgnore]
    public string Password { get; private set; }
}