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
        [HttpPost]
        public async Task<ActionResult<Taks?>> CreateOrUpdateTask(TaskDto taskDto)
        {
            var task = await service.CreateOrUpdateTask(taskDto);
            if (task is null)
            {
                BadRequest("Task not exists!");
            }

            return (task);
        }

        [HttpPost("Remove")]
        public async Task<ActionResult<Taks>> RemoveTask(Guid id)
        {
            var task = await service.RemoveTask(id);
            if (task is null)
            {
                BadRequest("Task not exists!") ;
            }

            return Ok(task);
        }
    }
}
