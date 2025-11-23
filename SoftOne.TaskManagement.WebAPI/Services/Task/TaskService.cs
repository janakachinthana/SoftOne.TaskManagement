using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.WebAPI.Context;
using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Task;
using SoftOne.TaskManagement.WebAPI.Entities.Taks;
using System.Drawing.Printing;
using System.Security.Claims;

namespace SoftOne.TaskManagement.WebAPI.Services.Task
{
    public class TaskService(AppDbContext context, IHttpContextAccessor httpContextAccessor) : ITaskService
    {
        Guid currentUserId = Guid.TryParse(httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var parsedId)
           ? parsedId
           : Guid.Empty;

        public async Task<TaskWork?> CreateOrUpdateTask(TaskDto taskDto)
        {

            TaskWork? task;

            task = await context.Taks.FindAsync(taskDto.Id);
            if (task is null)
            {
                task = new TaskWork
                {
                    Title = taskDto.Title,
                    Description = taskDto.Description,
                    DueDate = taskDto.DueDate,
                    Status = taskDto.Status,
                    UserId = currentUserId,
                    CreatBy = currentUserId,
                    CreatedOn = DateTime.UtcNow,
                };
                context.Taks.Add(task);

            }
            else 
            {
                task.Title = taskDto.Title;
                task.Description = taskDto.Description;
                task.DueDate = taskDto.DueDate;
                task.Status = taskDto.Status;
                task.UserId = taskDto.UserId;
                task.Modifiedby = currentUserId;
                task.ModifiedOn = DateTime.UtcNow;
                context.Taks.Update(task);
            }

            await context.SaveChangesAsync();
            return task;

        }

        public async Task<TaskWork?> RemoveTask(Guid id)
        {
            TaskWork? task = await context.Taks.FindAsync(id);
            if (task is null)
            {
                return null;
            }

            context.Taks.Remove(task);
            await context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskWork?> GetTaskById(Guid id)
        {
            return await context.Taks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<(IEnumerable<TaskWork> Items, int TotalCount)> GetUserTasks(int page = 1, int pageSize = 10)
        {
            var query = context.Taks.Where(t => t.UserId == currentUserId).AsQueryable();
            var total = await query.CountAsync();
            var items = await query.OrderBy(t => t.CreatedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, total);
        }

        public async Task<(IEnumerable<TaskWork> Items, int TotalCount)> GetAllTasks(int page =1, int pageSize =10)
        {
            var query = context.Taks.AsQueryable();
            var total = await query.CountAsync();
            var items = await query.OrderBy(t => t.CreatedOn)
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, total);
        }

        public async Task<bool> AssignUserForTask(UserTaskDto taskDto)
        {
            var task = await context.Taks.FindAsync(taskDto.TaskId);
            if (task is null)
            {
                return false;
            }
            task.UserId = taskDto.UserId;

            context.Update(task);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
