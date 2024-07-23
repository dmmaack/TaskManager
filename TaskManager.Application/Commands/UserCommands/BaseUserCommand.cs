using System.ComponentModel.DataAnnotations;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;

namespace TaskManager.Application.Commands.UserCommands;

public class BaseUserCommand : IRequest<NotificationResult<UserDTO>>
{
    
}