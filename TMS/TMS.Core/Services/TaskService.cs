using Microsoft.EntityFrameworkCore;
using TMS.Core.Models;
using TMS.Core.Models.Filters;
using TMS.Core.Models.Utility;
using TMS.Core.Services.Interfaces;
using TMS.Data.DAL;

namespace TMS.Core.Services;

public class TaskService(TMSDbContext dbContext) : ITaskService
{
    public async Task<PaginatedResult<TaskItem>> GetTasksAsync(TaskFilter filter)
    {
        var query = dbContext.Tasks.AsQueryable();

        if (filter.IsCompleted.HasValue)
        {
            query = query.Where(t => t.IsCompleted == filter.IsCompleted.Value);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderBy(t => t.Id)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(t => new TaskItem
            {
                Id = t.Id,
                Subject = t.Subject,
                Description = t.Description,
                IsCompleted = t.IsCompleted
            })
            .ToListAsync();

        return new PaginatedResult<TaskItem>
        {
            Items = items,
            Page = filter.Page,
            PageSize = filter.PageSize,
            TotalCount = totalCount
        };
    }
}
