using Microsoft.EntityFrameworkCore;
using TMS.Core.Extensions;
using TMS.Core.Models;
using TMS.Core.Models.Filters;
using TMS.Core.Models.Utility;
using TMS.Core.Services.Interfaces;
using TMS.Data.DAL;
using TMS.Data.Entities;

namespace TMS.Core.Services;

public class TaskService(TMSDbContext dbContext) : ITaskService
{
    public async Task<PaginatedResult<TaskItem>> GetTasksAsync(TaskFilter filter)
    {
        var query = dbContext.Tasks.AsNoTracking();

        if (filter.IsCompleted.HasValue)
        {
            query = query.Where(t => t.IsCompleted == filter.IsCompleted.Value);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderByDescending(t => t.SortOrder)
            .ThenByDescending(t => t.CreatedAt)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return new PaginatedResult<TaskItem>
        {
            Items = items.Select(t => t.ToModel()),
            Page = filter.Page,
            PageSize = filter.PageSize,
            TotalCount = totalCount
        };
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int id)
    {
        var entity = await dbContext.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        return entity?.ToModel();
    }

    public async Task<TaskItem> CreateTaskAsync(CreateTask create)
    {
        var maxSortOrder = await dbContext.Tasks.MaxAsync(t => (int?)t.SortOrder) ?? -1;

        var entity = new TaskEntity
        {
            Subject = create.Subject,
            Description = create.Description,
            IsCompleted = false,
            SortOrder = maxSortOrder + 1
        };

        dbContext.Tasks.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.ToModel();
    }

    public async Task<TaskItem?> UpdateTaskAsync(int id, UpdateTask update)
    {
        var entity = await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

        if (entity is null)
        {
            return null;
        }

        entity.Subject = update.Subject;
        entity.Description = update.Description;
        entity.IsCompleted = update.IsCompleted;

        await dbContext.SaveChangesAsync();

        return entity.ToModel();
    }

    public async Task<TaskItem?> ToggleCompletedAsync(int id)
    {
        var entity = await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

        if (entity is null)
        {
            return null;
        }

        entity.IsCompleted = !entity.IsCompleted;

        await dbContext.SaveChangesAsync();

        return entity.ToModel();
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var entity = await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

        if (entity is null)
        {
            return false;
        }

        dbContext.Tasks.Remove(entity);
        await dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ReorderTasksAsync(IEnumerable<int> taskIds)
    {
        var ids = taskIds.ToList();
        var tasks = await dbContext.Tasks
            .Where(t => ids.Contains(t.Id))
            .ToListAsync();

        if (tasks.Count != ids.Count)
        {
            return false;
        }

        // Get the max SortOrder among the tasks being reordered
        var maxSortOrder = tasks.Max(t => t.SortOrder);

        // First item in list gets highest SortOrder (appears first in descending order)
        for (var i = 0; i < ids.Count; i++)
        {
            var task = tasks.First(t => t.Id == ids[i]);
            task.SortOrder = maxSortOrder - i;
        }

        await dbContext.SaveChangesAsync();

        return true;
    }
}
