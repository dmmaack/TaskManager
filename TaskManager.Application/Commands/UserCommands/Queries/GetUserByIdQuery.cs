using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;

namespace TaskManager.Application.Commands.UserCommands.Queries;

public class GetUserByIdQuery : IRequest<NotificationResult<UserDTO>>
{
    public long Id { get; set; }
    public bool AsNoTracking { get; set; } = true;
}