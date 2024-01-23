
using System.Net;
using Asp.Versioning;
using Manager.Application.Users.Commands;
using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{   
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version=apiVersion}/[controller]")]
    public class AuthController(IMediator mediator, INotificationHandler<DomainNotification> notification) : BaseController(notification)
    {
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> Post(LoginUserCommand loginUserCommand)
        {
            var token = await mediator.Send(loginUserCommand);
            return OkOrNoContent(token);
        }
    }
}