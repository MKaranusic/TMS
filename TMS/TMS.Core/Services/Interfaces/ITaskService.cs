using TMS.Core.Models;
using TMS.Core.Models.Filters;
using TMS.Core.Models.Utility;

namespace TMS.Core.Services.Interfaces;

public interface ITaskService
{
    Task<PaginatedResult<TaskItem>> GetTasksAsync(TaskFilter filter);
    Task<TaskItem?> GetTaskByIdAsync(int id);
    Task<TaskItem> CreateTaskAsync(CreateTask create);
    Task<TaskItem?> UpdateTaskAsync(int id, UpdateTask update);
    Task<TaskItem?> ToggleCompletedAsync(int id);
    Task<bool> DeleteTaskAsync(int id);
}
