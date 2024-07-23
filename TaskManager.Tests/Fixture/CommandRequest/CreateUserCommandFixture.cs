using Bogus.DataSets;
using TaskManager.Application.Commands.UserCommands.Create;

namespace TaskManager.Tests.Fixture.CommandRequest;

public class CreateUserCommandFixture
{
    public static CreateUserCommand CreateValid_CreateUserCommand() => 
        new CreateUserCommand(name: new Name().FullName(),
                                email: new Internet().Email(),
                                userName: new Name().FirstName(),
                                password:new Internet().Password(length: 12, prefix: "%"));

    public static CreateUserCommand CreateInvalid_CreateUserCommand() => 
        new CreateUserCommand(name: new Name().FullName(),
                                email: new Internet().Email(),
                                userName: new Name().FirstName(),
                                password: new Internet().Password(length: 5));
}