using System.Reflection;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Commands.ProjectCommands.Create;
using TaskManager.Application.Commands.UserCommands.Create;
using TaskManager.Application.Commands.UserCommands.Queries;
using TaskManager.Domain.DTO;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.UnitOfWork;
using TaskManager.Infra.Context;
using TaskManager.Infra.Repositories;

namespace TaskManager.CrossCutting.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        // SQL Connection
        var sqlConnection = configuration.GetConnectionString("SqlConnection");

        services.AddDbContext<AppDbContext>(options =>
                                            options.UseSqlServer(sqlConnection));

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // MediatR
        var handlers = AppDomain.CurrentDomain.Load("TaskManager.Application");
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(handlers);
        });
        
        services.AddValidatorsFromAssembly(Assembly.Load("TaskManager.Application"));

        // AutoMappers
        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserEntity, UserDTO>().ReverseMap();
            cfg.CreateMap<UserEntity, CreateUserCommand>().ReverseMap();
            cfg.CreateMap<UserEntity, SearchUserBySpecificationQuery>().ReverseMap();
            cfg.CreateMap<ProjectEntity, CreateProjectCommand>().ReverseMap();
            cfg.CreateMap<ProjectEntity, ProjectDTO>().ReverseMap();
        });

        services.AddSingleton(autoMapperConfig.CreateMapper());

        return services;

    }
}