namespace TMS.API.Models.DTOs.Request;

public record ReorderTasksRequest
{
    public required IEnumerable<int> TaskIds { get; init; }
}
