using Abp.Domain.Entities.Auditing;

namespace SoftOne.TaskManagement.WebAPI.Entities.Taks
{
    public class TaskWork
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public Guid? UserId { get; set; } = Guid.Empty;
        public Guid CreatBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? Modifiedby { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
