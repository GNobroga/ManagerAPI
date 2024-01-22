using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{   
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        [Route("/api/v1/users")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {   
            return await userService.FindAllAsync();
        }
    }
}