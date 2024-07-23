using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;

namespace TaskManager.Application.Commands.UserCommands.Queries
{
    public class SearchUserBySpecificationQuery : IRequest<NotificationResult<IList<UserDTO>>>
    {
        public string Search { get; set; }
    }
}