using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Task;
using SoftOne.TaskManagement.WebAPI.Entities.Taks;
using SoftOne.TaskManagement.WebAPI.Services.Task;

namespace SoftOne.TaskManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskService service) : ControllerBase
    {
        [Authorize]
        [HttpPost("Save")]
        public async Task<ActionResult<TaskWork?>> CreateOrUpdateTask(TaskDto taskDto)
        {
            var task = await service.CreateOrUpdateTask(taskDto);
            if (task is null)
            {
                return BadRequest("Task not exists!");
            }

            return (task);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TaskWork>> RemoveTask(Guid id)
        {
            var task = await service.RemoveTask(id);
            if (task is null)
            {
                return BadRequest("Task not exists!");
            }

            return Ok(task);
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaskWork>> GetTaskById(Guid id)
        {
            var task = await service.GetTaskById(id);
            if (task is null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [Authorize]
        [HttpGet("MyTasks")]
        public async Task<ActionResult> GetUserTasks([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var (items, total) = await service.GetUserTasks(page, pageSize);

            var response = new
            {
                Items = items,
                TotalCount = total,
                Page = page,
                PageSize = pageSize
            };

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAllTasks([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var (items, total) = await service.GetAllTasks(page, pageSize);

            var response = new
            {
                Items = items,
                TotalCount = total,
                Page = page,
                PageSize = pageSize
            };

            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<TaskWork?>> AssignUserForTask(UserTaskDto userTaskDto)
        {
            var task = await service.AssignUserForTask(userTaskDto);
            if (task is false)
            {
                return BadRequest("Task not exists!");
            }
            return Ok(task);
        }
    }
}
