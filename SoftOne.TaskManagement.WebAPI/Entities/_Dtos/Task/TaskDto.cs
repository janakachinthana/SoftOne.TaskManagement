namespace SoftOne.TaskManagement.WebAPI.Entities._Dtos.Task
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public Guid? UserId { get; set; } = Guid.Empty;
    }
}
