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
            .OrderByDescending(t => t.CreatedAt)
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
        var entity = new TaskEntity
        {
            Subject = create.Subject,
            Description = create.Description,
            IsCompleted = false
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
}
