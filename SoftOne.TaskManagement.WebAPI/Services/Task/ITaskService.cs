using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Task;
using SoftOne.TaskManagement.WebAPI.Entities.Taks;

namespace SoftOne.TaskManagement.WebAPI.Services.Task
{
    public interface ITaskService
    {
        public Task<TaskWork?> CreateOrUpdateTask(TaskDto task);
        public Task<TaskWork?> RemoveTask(Guid id);
    }
}
