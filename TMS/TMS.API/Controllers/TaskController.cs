using Microsoft.AspNetCore.Mvc;
using TMS.API.Models.DTOs.Response;

namespace TMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
    {
        //var tasks = await _taskService.GetTasks();

        //return Ok(tasks.Select(t => t.ToDto()));
        return Ok();
    }
}
