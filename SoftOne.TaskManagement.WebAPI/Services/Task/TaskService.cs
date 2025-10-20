using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.WebAPI.Context;
using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Task;
using SoftOne.TaskManagement.WebAPI.Entities.Taks;
using System.Security.Claims;

namespace SoftOne.TaskManagement.WebAPI.Services.Task
{
    public class TaskService(AppDbContext Context, IHttpContextAccessor httpContextAccessor) : ITaskService
    {
        Guid currentUserId = Guid.TryParse(httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var parsedId)
           ? parsedId
           : Guid.Empty;

        public async Task<TaskWork?> CreateOrUpdateTask(TaskDto taskDto)
        {

            TaskWork? task;

            task = await Context.Taks.FindAsync(taskDto.Id);
            if (task is null)
            {
                task = new TaskWork
                {
                    Title = taskDto.Title,
                    Description = taskDto.Description,
                    DueDate = taskDto.DueDate,
                    Status = taskDto.Status,
                    CreatorUserId = currentUserId
                };
                Context.Taks.Add(task);

            }
            else 
            {
                task.Title = taskDto.Title;
                task.Description = taskDto.Description;
                task.DueDate = taskDto.DueDate;
                task.Status = taskDto.Status;
                task.LastModifierUserId = currentUserId;
                task.LastModificationTime = DateTime.Now;

                Context.Taks.Update(task);
            }

            await Context.SaveChangesAsync();
            return task;

        }

        public async Task<TaskWork?> RemoveTask(Guid id)
        {
            TaskWork? task = await Context.Taks.FindAsync(id);
            if (task is null)
            {
                return null;
            }

            Context.Taks.Remove(task);
            await Context.SaveChangesAsync();

            return task;
        }
    }
}
