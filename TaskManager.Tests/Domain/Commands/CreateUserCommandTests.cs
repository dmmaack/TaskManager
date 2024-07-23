using System.Linq.Expressions;
using AutoMapper;
using Moq;
using TaskManager.Application.Commands.UserCommands.Create;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.UnitOfWork;
using TaskManager.Tests.Configurations;
using TaskManager.Tests.Fixture.CommandRequest;

namespace TaskManager.Tests.Domain.Commands;

public class CreateUserCommandTests
{
    CreateUserCommandHandler _createUserCommandHandler;

    private readonly IMapper _mapper;

    //Mock<IUserRepository> _mockUserRepository;
    Mock<IUnitOfWork> _mockUnitOfWork;

    public CreateUserCommandTests()
    {
        _mapper = AutoMapperConfiguration.GetConfiguration();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _createUserCommandHandler = new CreateUserCommandHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact(DisplayName = "Create Valid User Return Success True")]
    public async Task Create_WhenIsValid_ReturnSuccessTrue()
    {
        // arrange
        var userToCreateCommand = CreateUserCommandFixture.CreateValid_CreateUserCommand();
        var userEntity = _mapper.Map<UserEntity>(userToCreateCommand);

        _mockUnitOfWork.Setup(
            repo => repo.UserRepository.GetAsync(It.IsAny<Expression<Func<UserEntity, bool>>>(), true)
            ).ReturnsAsync(() => null);

        _mockUnitOfWork.Setup(
            repo => repo.UserRepository.CreateAsync(It.IsAny<UserEntity>())
        ).ReturnsAsync(userEntity);

        // act
        var result = await _createUserCommandHandler.Handle(userToCreateCommand, new CancellationToken());

        //assert
        Assert.True(result.Success);
    }

    [Fact(DisplayName = "Create Invalid User Return Success False")]
    public async void Create_WhenIsInvalid_ReturnSuccessFalse()
    {
        // Arrange
        var userToCreateCommand = CreateUserCommandFixture.CreateInvalid_CreateUserCommand();
        var userEntity = _mapper.Map<UserEntity>(userToCreateCommand);

        _mockUnitOfWork.Setup(
            repo => repo.UserRepository.GetAsync(It.IsAny<Expression<Func<UserEntity, bool>>>(), true)
        ).ReturnsAsync(() => null);
        
        // Act
        var result = await _createUserCommandHandler.Handle(userToCreateCommand, new CancellationToken());

        // Assert
        Assert.False(result.Success);
    }

    [Fact(DisplayName = "Create Exists User Return Success False")]
    public async void Create_WhenIsExists_ReturnUser()
    {
        // Arrange
        var userToCreateCommand = CreateUserCommandFixture.CreateInvalid_CreateUserCommand();
        var userEntity = _mapper.Map<UserEntity>(userToCreateCommand);
        var resultList = new List<UserEntity>
        {
            userEntity
        };

        _mockUnitOfWork.Setup(
            repo => repo.UserRepository.GetAsync(It.IsAny<Expression<Func<UserEntity, bool>>>(), true)
        ).ReturnsAsync(resultList);

        // Act
        var result = await _createUserCommandHandler.Handle(userToCreateCommand, new CancellationToken());

        // Assert
        Assert.False(result.Success);
    }
}