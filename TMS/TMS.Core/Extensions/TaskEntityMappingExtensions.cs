using TMS.Core.Models;
using TMS.Data.Entities;

namespace TMS.Core.Extensions;

public static class TaskEntityMappingExtensions
{
    public static TaskItem ToModel(this TaskEntity entity)
    {
        return new TaskItem
        {
            Id = entity.Id,
            Subject = entity.Subject,
            Description = entity.Description,
            IsCompleted = entity.IsCompleted
        };
    }
}
