using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.WebAPI.Context;
using SoftOne.TaskManagement.WebAPI.Entities._Dtos.User;
using SoftOne.TaskManagement.WebAPI.Entities.Auth;

namespace SoftOne.TaskManagement.WebAPI.Services.Users
{
    public class UserService(AppDbContext context, IMapper mapper) : IUserService
    {
        public async Task<IEnumerable<UserResponseDto?>> GetAllUsersAsync()
        {
            var users = await context.Users.ToListAsync();
            return mapper.Map<IEnumerable<UserResponseDto?>>(users);
        }

        public async Task<UserResponseDto> GetUserByIdAsync(Guid userId)
        {
            var user = await context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
               return mapper.Map<UserResponseDto>(user);
        }
    }
}
