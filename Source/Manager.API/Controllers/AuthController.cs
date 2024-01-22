
using Manager.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<string>> Post(LoginUserCommand loginUserCommand)
        {
            return await mediator.Send(loginUserCommand);
        }
    }
}