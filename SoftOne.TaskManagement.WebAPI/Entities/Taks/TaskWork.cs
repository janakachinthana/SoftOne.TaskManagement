using Abp.Domain.Entities.Auditing;

namespace SoftOne.TaskManagement.WebAPI.Entities.Taks
{
    public class TaskWork: AuditedEntity<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public new Guid CreatorUserId { get; set; } = Guid.Empty;
        public new Guid LastModifierUserId { get; set; } = Guid.Empty;
        public Guid UserId { get; set; } = Guid.Empty;

    }
}
