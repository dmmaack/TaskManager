using AutoMapper;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Commands.UserCommands.Queries;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, NotificationResult<IList<UserDTO>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<NotificationResult<IList<UserDTO>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await _userRepository.GetAllAsync();

        var allUsersDTO = _mapper.Map<IList<UserDTO>>(allUsers);

        return new NotificationResult<IList<UserDTO>>(true, 
                                                      new DomainNotification($"{allUsersDTO.Count()} usuário(s) encontrado(s).", 
                                                                                  System.Net.HttpStatusCode.Found),
                                                      allUsersDTO);
    }
}