
using Asp.Versioning;
using Manager.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{   
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version=apiVersion}/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<string>> Post(LoginUserCommand loginUserCommand)
        {
            return await mediator.Send(loginUserCommand);
        }
    }
}