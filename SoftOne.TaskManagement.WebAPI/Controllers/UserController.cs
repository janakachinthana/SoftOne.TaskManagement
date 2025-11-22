using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftOne.TaskManagement.WebAPI.Services.Users;

namespace SoftOne.TaskManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]   
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await userService.GetUserByIdAsync(id);
            return Ok(user);
        }
    }
}
