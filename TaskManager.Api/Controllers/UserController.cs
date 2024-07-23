using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.UserCommands.Create;
using TaskManager.Application.Commands.UserCommands.Queries;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {

            var query = new GetUserByIdQuery() { Id = id };
            var users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpGet]
        [Route("GetUserAndProjects/{id}")]
        public async Task<IActionResult> GetUserAndProjects(long id)
        {

            var query = new GetUserByIdQuery() { Id = id, AsNoTracking = false };
            var users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpGet]
        [Route("SearchUsers")]
        public async Task<IActionResult> SearchUsers([FromQuery] string search)
        {
            var query = new SearchUserBySpecificationQuery() { Search = search };
            var users = await _mediator.Send(query);

            if(!users.Success)
                return StatusCode((int)users.Notification.StatusCode, users.Data);

            return Ok(users);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand userCommand)
        {
            var createUser = await _mediator.Send(userCommand);
            return Ok(createUser);
        }
    }
}