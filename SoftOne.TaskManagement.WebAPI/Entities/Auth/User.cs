using Abp.Domain.Entities.Auditing;

namespace SoftOne.TaskManagement.WebAPI.Entities.Auth
{
    public class User: AuditedEntity<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NIC { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public new Guid CreatorUserId { get; set; } = Guid.Empty;
        public new Guid LastModifierUserId { get; set; } = Guid.Empty;
    }
}
