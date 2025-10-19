using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Task;
using SoftOne.TaskManagement.WebAPI.Entities.Taks;

namespace SoftOne.TaskManagement.WebAPI.Services.Task
{
    public interface ITaskService
    {
        public Task<Taks?> CreateOrUpdateTask(TaskDto task);
        public Task<Taks?> RemoveTask(Guid id);
    }
}
