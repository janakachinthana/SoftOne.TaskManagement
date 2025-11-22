namespace SoftOne.TaskManagement.WebAPI.Entities._Dtos.Task
{
    public class UserTaskDto
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public Guid TaskId { get; set; } = Guid.Empty;
    }
}
