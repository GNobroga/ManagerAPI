using Asp.Versioning;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{   
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/users")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {   
            return await mediator.Send(new GetAllUsersQuery());
        }
    }
}