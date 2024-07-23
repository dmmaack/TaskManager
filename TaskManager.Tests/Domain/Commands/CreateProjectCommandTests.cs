using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using TaskManager.Application.Commands.ProjectCommands.Create;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.UnitOfWork;
using TaskManager.Tests.Configurations;
using TaskManager.Tests.Fixture.CommandRequest;

namespace TaskManager.Tests.Domain.Commands
{
    public class CreateProjectCommandTests
    {
        private readonly CreateProjectCommandHandler _commandHandler;
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public CreateProjectCommandTests()
        {
            _mapper = AutoMapperConfiguration.GetConfiguration();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _commandHandler = new CreateProjectCommandHandler(_mockUnitOfWork.Object, _mapper);
        }

        [Fact(DisplayName = "Create Valid Project Return Success True")]
        public async Task Create_WhenIsValid_ReturnSucessTrue()
        {
            // Arrange
            var createProjectCommand = CreateProjectCommandFixture.CreateValid_CreateProjectCommand();
            var projectEntity = _mapper.Map<ProjectEntity>(createProjectCommand);

            _mockUnitOfWork.Setup(
                repo => repo.ProjectRepository.CreateAsync(It.IsAny<ProjectEntity>())
            ).ReturnsAsync(projectEntity);

            // Act
            var result = await _commandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(result.Success);

        }

        [Fact(DisplayName = "Create Invalid Project Return Success False")]
        public async Task Create_WhenIsInvalid_ReturnSucessFalse()
        {
            // Arrange
            var createProjectCommand = CreateProjectCommandFixture.CreateInvalid_CreateProjectCommand();

            // Act
            var result = await _commandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.False(result.Success);

        }
    }
}