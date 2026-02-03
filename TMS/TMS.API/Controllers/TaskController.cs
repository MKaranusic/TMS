using Microsoft.AspNetCore.Mvc;
using TMS.API.Extensions;
using TMS.API.Models.DTOs.Request;
using TMS.API.Models.DTOs.Response;
using TMS.Core.Models.Filters;
using TMS.Core.Services.Interfaces;

namespace TMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController(ITaskService taskService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<TaskDto>>> GetTasks([FromQuery] TaskFilterRequest request)
    {
        var filter = new TaskFilter
        {
            Page = request.Page,
            PageSize = request.PageSize,
            IsCompleted = request.IsCompleted
        };

        var result = await taskService.GetTasksAsync(filter);

        return Ok(result.ToResponse(t => t.ToDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskDto>> GetTaskById(int id)
    {
        var task = await taskService.GetTaskByIdAsync(id);

        if (task is null)
            return NotFound();

        return Ok(task.ToDto());
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskRequest request)
    {
        var task = await taskService.CreateTaskAsync(request.ToModel());

        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task.ToDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TaskDto>> UpdateTask(int id, [FromBody] UpdateTaskRequest request)
    {
        var task = await taskService.UpdateTaskAsync(id, request.ToModel());

        if (task is null)
            return NotFound();

        return Ok(task.ToDto());
    }

    [HttpPatch("{id:int}/toggle")]
    public async Task<ActionResult<TaskDto>> ToggleCompleted(int id)
    {
        var task = await taskService.ToggleCompletedAsync(id);

        if (task is null)
            return NotFound();

        return Ok(task.ToDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var deleted = await taskService.DeleteTaskAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
