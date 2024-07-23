using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;

namespace TaskManager.Application.Commands.UserCommands.Queries;

public class GetUsersQuery : IRequest<NotificationResult<IList<UserDTO>>>
{
    
}