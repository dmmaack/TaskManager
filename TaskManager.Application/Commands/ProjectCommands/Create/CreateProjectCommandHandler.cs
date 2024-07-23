using AutoMapper;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.UnitOfWork;

namespace TaskManager.Application.Commands.ProjectCommands.Create;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, NotificationResult<ProjectDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<NotificationResult<ProjectDTO>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var createProjectMap = _mapper.Map<ProjectEntity>(request);
        createProjectMap.SetRegisterDate(DateTime.UtcNow);
        createProjectMap.SetIsActive(true);
        createProjectMap.ValidateProject();

        if(!createProjectMap.IsValid())
            return new NotificationResult<ProjectDTO>(false, new DomainNotification("Houve um problema ao cadastrar o projeto.", 
                                                                                 createProjectMap.GetErrors(), 
                                                                                 System.Net.HttpStatusCode.UnprocessableEntity),
                                                new ProjectDTO());

        var projectCreated = await _unitOfWork.ProjectRepository.CreateAsync(createProjectMap);
        await _unitOfWork.CommitAsync();

        var projectDTOMap = _mapper.Map<ProjectDTO>(projectCreated);

        return new NotificationResult<ProjectDTO>(true, new DomainNotification("Projeto inserido com sucesso.", 
                                                                                [], 
                                                                                System.Net.HttpStatusCode.UnprocessableEntity),
                                                                                projectDTOMap);
    }
}