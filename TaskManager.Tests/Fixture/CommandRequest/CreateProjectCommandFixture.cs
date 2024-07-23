using Bogus;
using TaskManager.Application.Commands.ProjectCommands.Create;

namespace TaskManager.Tests.Fixture.CommandRequest;

public static class CreateProjectCommandFixture
{
    public static CreateProjectCommand CreateValid_CreateProjectCommand() => 
        new Faker<CreateProjectCommand>().StrictMode(true)
            .RuleFor(x => x.ProjectName, o => string.Join(" ", o.Lorem.Words(3)))
            .RuleFor(x => x.StartDate, o => o.Date.Future())
            .RuleFor(x => x.EndDate, o => o.Date.Future())
            .RuleFor(x => x.UserId, o => o.IndexFaker);

    public static CreateProjectCommand CreateInvalid_CreateProjectCommand() => 
        new Faker<CreateProjectCommand>().StrictMode(true)
            .RuleFor(x => x.ProjectName, o => string.Empty)
            .RuleFor(x => x.StartDate, o => o.Date.Future())
            .RuleFor(x => x.EndDate, o => o.Date.Future())
            .RuleFor(x => x.UserId, o => o.IndexFaker);
    
}