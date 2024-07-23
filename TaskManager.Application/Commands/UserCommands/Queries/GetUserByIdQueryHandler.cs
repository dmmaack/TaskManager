using AutoMapper;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Commands.UserCommands.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, NotificationResult<UserDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<NotificationResult<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var selectedUser = await _userRepository.GetByIdAsync(request.Id, request.AsNoTracking);

        if(selectedUser == null || selectedUser.Id != request.Id)
            return new NotificationResult<UserDTO>(false, new DomainNotification("Identificador de usuário não existe.", 
                                                                             System.Net.HttpStatusCode.UnprocessableEntity),
                                            new UserDTO());
        
        var userDTO = _mapper.Map<UserDTO>(selectedUser);

        return new NotificationResult<UserDTO>(true, 
                                                new DomainNotification("1 usuário(s) encontrado.", 
                                                                             System.Net.HttpStatusCode.Found),
                                                userDTO);

    }
}