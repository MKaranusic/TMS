using Microsoft.AspNetCore.Mvc;
using TMS.API.Models.DTOs.Request;
using TMS.API.Models.DTOs.Response;
using TMS.Core.Models;
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

        var response = new PaginatedResponse<TaskDto>
        {
            Items = result.Items.Select(t => new TaskDto
            {
                Id = t.Id,
                Subject = t.Subject,
                Description = t.Description,
                IsCompleted = t.IsCompleted
            }),
            Page = result.Page,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount
        };

        return Ok(response);
    }
}
