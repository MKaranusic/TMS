using TMS.API.Models.DTOs.Request;
using TMS.API.Models.DTOs.Response;
using TMS.Core.Models;

namespace TMS.API.Extensions;

public static class TaskMappingExtensions
{
    public static TaskDto ToDto(this TaskItem task)
    {
        return new TaskDto
        {
            Id = task.Id,
            Subject = task.Subject,
            Description = task.Description,
            IsCompleted = task.IsCompleted
        };
    }

    public static IEnumerable<TaskDto> ToDto(this IEnumerable<TaskItem> tasks)
    {
        return tasks.Select(t => t.ToDto());
    }

    public static CreateTask ToModel(this CreateTaskRequest request)
    {
        return new CreateTask
        {
            Subject = request.Subject,
            Description = request.Description
        };
    }

    public static UpdateTask ToModel(this UpdateTaskRequest request)
    {
        return new UpdateTask
        {
            Subject = request.Subject,
            Description = request.Description,
            IsCompleted = request.IsCompleted
        };
    }
}
