using System.ComponentModel.DataAnnotations;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;

namespace TaskManager.Application.Commands.UserCommands.Create;

public class CreateUserCommand: IRequest<NotificationResult<UserDTO>>
{
    [Required(ErrorMessage = "O nome não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]  
    public string Name { get; set; }

    [Required(ErrorMessage = "O email não pode ser vazio.")]
    [MinLength(10, ErrorMessage = "O email deve ter no mínimo 10 caracteres.")]
    [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres.")]
    [EmailAddress(ErrorMessage = "O email informado não é válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O UserName não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O UserName deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O UserName deve ter no máximo 80 caracteres.")] 
    public string UserName { get; set; }

    [Required(ErrorMessage = "A senha não pode ser vazia.")]
    [MinLength(10, ErrorMessage = "A senha deve ter no mínimo 10 caracteres.")]
    [MaxLength(80, ErrorMessage = "A senha deve ter no máximo 80 caracteres.")]
    public string Password { get; set; }
    
    public CreateUserCommand(string name, string email, string userName, string password)
    {
        Name = name;
        Email = email;
        UserName = userName;
        Password = password;
    }
}

