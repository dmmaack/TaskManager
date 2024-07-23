using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;

namespace TaskManager.Application.Commands.ProjectCommands.Queries;

public class GetProjectsByUserIdQuery : IRequest<NotificationResult<IEnumerable<ProjectDTO>>>
{
    public long UserId { get; set; }
}