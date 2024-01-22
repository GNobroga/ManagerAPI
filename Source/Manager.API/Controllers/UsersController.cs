using Asp.Versioning;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{   
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/users")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {   
            return await userService.FindAllAsync();
        }
    }
}