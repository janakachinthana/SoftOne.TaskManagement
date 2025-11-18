using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Task;
using SoftOne.TaskManagement.WebAPI.Entities.Taks;

namespace SoftOne.TaskManagement.WebAPI.Services.Task
{
    public interface ITaskService
    {
        public Task<TaskWork?> CreateOrUpdateTask(TaskDto task);
        public Task<TaskWork?> RemoveTask(Guid id);
        public Task<TaskWork?> GetTaskById(Guid id);
        public Task<IEnumerable<TaskWork>> GetUserTasks();
        public Task<(IEnumerable<TaskWork> Items, int TotalCount)> GetAllTasks(int page =1, int pageSize =10);
    }
}
