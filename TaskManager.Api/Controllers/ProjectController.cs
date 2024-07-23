using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.ProjectCommands.Create;
using TaskManager.Application.Commands.ProjectCommands.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/v1/[controller]")]
public class ProjectController : Controller
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("createProject")]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
    {
        var project = await _mediator.Send(command);

        return Ok(project);

    }

    [HttpGet]
    [Route("getAllByUserId/{userId}")]
    public async Task<IActionResult> GetProjectsByUserId(long userId)
    {
        var query = new GetProjectsByUserIdQuery() { UserId = userId };
        var projects = await _mediator.Send(query);

        return Ok(projects);
    }
}