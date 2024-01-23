using System.Net;
using Asp.Versioning;
using Manager.Application.DTOs;
using Manager.Application.Users.Commands;
using Manager.Application.Users.Queries;
using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{   
    [Authorize]
    [Produces(CONTENT_TYPE)]
    [Consumes(CONTENT_TYPE)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UsersController(IMediator mediator, INotificationHandler<DomainNotification> notification) : BaseController(notification)
    {
        private const string CONTENT_TYPE = "application/json";

        [ProducesResponseType(typeof(List<UserDTO>), (int) HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            var users = await mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [ProducesResponseType(typeof(UserDTO), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [HttpGet("{id:int}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await mediator.Send(new GetUserByIdQuery(id));
            return OkOrNotFound(user);
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDTO), (int) HttpStatusCode.Created)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand createUserCommand)
        {   
            var user = await mediator.Send(createUserCommand);
            var uri = Url.Link("Get", new { user.Id });
            return CreatedContent(uri, user);
        }

        [ProducesResponseType(typeof(UserDTO), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {   
            var deleted = await mediator.Send(new DeleteUserCommand(id));
            return OkOrNotFound(deleted);
        }

        [ProducesResponseType(typeof(UserDTO), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand updateUserCommand)
        {   
            updateUserCommand.Id = id;
            var user = await mediator.Send(updateUserCommand);
            return AcceptedContent(user);
        }
    }
}