namespace SoftOne.TaskManagement.WebAPI.Entities._Dtos.Auth
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NIC { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
