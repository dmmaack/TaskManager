using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.UnitOfWork;

namespace TaskManager.Application.Commands.UserCommands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, NotificationResult<UserDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) //IValidator<CreateUserCommand> validator
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<NotificationResult<UserDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<UserEntity, bool>> expression = expression => expression.Equals(request.Email);
        var userExists = await _unitOfWork.UserRepository.GetAsync(expression);

        if (userExists != null)
            return new NotificationResult<UserDTO>(false, 
                                                    new DomainNotification("Usuário já existe na base de dados.", 
                                                                            [], 
                                                                            System.Net.HttpStatusCode.UnprocessableEntity),
                                                    new UserDTO());

        var createUser = _mapper.Map<UserEntity>(request);
        createUser.SetIsActive(true);
        createUser.SetRegisterDate(DateTime.UtcNow);
        createUser.ValidateUser();

        if(!createUser.IsValid())
            return new NotificationResult<UserDTO>(false, new DomainNotification("Houve um problema ao cadastrar o usuário.", 
                                                                                 createUser.GetErrors(), 
                                                                                 System.Net.HttpStatusCode.UnprocessableEntity),
                                                new UserDTO());

        await _unitOfWork.UserRepository.CreateAsync(createUser);
        await _unitOfWork.CommitAsync();

        var userDTOMap = _mapper.Map<UserDTO>(createUser);

        return new NotificationResult<UserDTO>(true, new DomainNotification("Usuário inserido com sucesso.", 
                                                                            [], 
                                                                            System.Net.HttpStatusCode.UnprocessableEntity),
                                                userDTOMap);
    }
}