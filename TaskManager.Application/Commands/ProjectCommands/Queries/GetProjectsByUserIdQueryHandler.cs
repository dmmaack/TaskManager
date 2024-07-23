using AutoMapper;
using MediatR;
using TaskManager.Core.Communications.Messages.Notifications;
using TaskManager.Domain.DTO;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.UnitOfWork;

namespace TaskManager.Application.Commands.ProjectCommands.Queries;

public class GetProjectsByUserIdQueryHandler : IRequestHandler<GetProjectsByUserIdQuery, NotificationResult<IEnumerable<ProjectDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectsByUserIdQueryHandler(IMapper mapper, IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<NotificationResult<IEnumerable<ProjectDTO>>> Handle(GetProjectsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var getProjects = await _unitOfWork.ProjectRepository.GetAllByUserIdAsync(request.UserId);

        var allProjectsDTO = _mapper.Map<IEnumerable<ProjectDTO>>(getProjects);

        return new NotificationResult<IEnumerable<ProjectDTO>>(true,
                                                                new DomainNotification($"{allProjectsDTO.Count()} usuário(s) encontrado(s).",
                                                                                        System.Net.HttpStatusCode.Found),
                                                                allProjectsDTO);
    }
}