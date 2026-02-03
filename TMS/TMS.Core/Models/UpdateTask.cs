namespace TMS.Core.Models;

public record UpdateTask
{
    public required string Subject { get; init; }
    public string? Description { get; init; }
    public bool IsCompleted { get; init; }
}
