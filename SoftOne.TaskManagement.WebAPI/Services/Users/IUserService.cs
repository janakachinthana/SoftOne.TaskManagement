using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Auth;
using SoftOne.TaskManagement.WebAPI.Entities._Dtos.User;
using SoftOne.TaskManagement.WebAPI.Entities.Auth;

namespace SoftOne.TaskManagement.WebAPI.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto?>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(Guid userId);

    }
}
