using AutoMapper;
using TaskManager.Application.Commands.ProjectCommands.Create;
using TaskManager.Application.Commands.UserCommands.Create;
using TaskManager.Application.Commands.UserCommands.Queries;
using TaskManager.Domain.DTO;
using TaskManager.Domain.Entities;

namespace TaskManager.Tests.Configurations;

public class AutoMapperConfiguration
{
    public static IMapper GetConfiguration()
    {
        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserEntity, UserDTO>().ReverseMap();
            cfg.CreateMap<UserEntity, CreateUserCommand>().ReverseMap();
            cfg.CreateMap<UserEntity, SearchUserBySpecificationQuery>().ReverseMap();
            cfg.CreateMap<ProjectEntity, CreateProjectCommand>().ReverseMap();
            cfg.CreateMap<ProjectEntity, ProjectDTO>().ReverseMap();

        });

        return autoMapperConfig.CreateMapper();
    }
}