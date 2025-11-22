using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Auth;
using SoftOne.TaskManagement.WebAPI.Entities.Auth;
using SoftOne.TaskManagement.WebAPI.Services.Auth;

namespace SoftOne.TaskManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("User already exists.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Lgin(UserLoginDto request)
        {
          var token = await authService.LogingAsync(request);
            if (token is null)
                return BadRequest("Invalid credentials.");

            return Ok(new { token = token });
        }

       
    }
}
