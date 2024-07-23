using System.ComponentModel.DataAnnotations;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;

namespace TaskManager.Application.Commands.ProjectCommands.Create;

public class CreateProjectCommand : IRequest<NotificationResult<ProjectDTO>>
{
    [Required(ErrorMessage = "O Nome do Projeto não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O Nome do Projeto deve ter no mínimo 5 caracteres.")]
    [MaxLength(150, ErrorMessage = "O Nome do Projeto deve ter no máximo 150 caracteres.")]
    public string ProjectName { get; set; }

    [Required(ErrorMessage = "A Data Inicial do Projeto não pode ser vazia.")]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "A Data Final do Projeto não pode ser vazia.")]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Um Usuário deve ser definido para o Projeto.")]
    [Range(1, int.MaxValue, ErrorMessage = "Um Usuário deve ser definido para o Projeto.")]
    public long UserId { get; set; }
}