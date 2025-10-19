using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Auth;
using SoftOne.TaskManagement.WebAPI.Entities.Auth;

namespace SoftOne.TaskManagement.WebAPI.Services.Auth
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserRegisterDto request);
        Task<string?> LogingAsync(UserLoginDto request);
    }
}
