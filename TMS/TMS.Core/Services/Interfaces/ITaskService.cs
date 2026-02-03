using TMS.Core.Models;
using TMS.Core.Models.Filters;
using TMS.Core.Models.Utility;

namespace TMS.Core.Services.Interfaces;

public interface ITaskService
{
    Task<PaginatedResult<TaskItem>> GetTasksAsync(TaskFilter filter);
}
