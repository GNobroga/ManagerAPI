using System.Net;
using Asp.Versioning;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Users.Commands;
using Manager.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{   
    [Produces(CONTENT_TYPE)]
    [Consumes(CONTENT_TYPE)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/users")]
    public class UsersController(IMediator mediator) : ControllerBase
    {

        private const string CONTENT_TYPE = "application/json";

        [ProducesResponseType(typeof(List<UserDTO>), (int) HttpStatusCode.OK)]
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {   
            return await mediator.Send(new GetAllUsersQuery());
        }

        [ProducesResponseType(typeof(UserDTO), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            return await mediator.Send(new GetUserByIdQuery(id));
        }

        [ProducesResponseType(typeof(UserDTO), (int) HttpStatusCode.Created)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(CreateUserCommand createUserCommand)
        {   
            var user = await mediator.Send(createUserCommand);
            return CreatedAtRoute("GetById", new { Id = user.Id }, user);
        }
    }
}