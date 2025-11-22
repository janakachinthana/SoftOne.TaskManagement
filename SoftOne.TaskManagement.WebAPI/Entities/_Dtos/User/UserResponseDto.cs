using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Auth;

namespace SoftOne.TaskManagement.WebAPI.Entities._Dtos.User
{
    public class UserResponseDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NIC { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
