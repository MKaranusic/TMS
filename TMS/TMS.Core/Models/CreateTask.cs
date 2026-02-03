namespace TMS.Core.Models;

public record CreateTask
{
    public required string Subject { get; init; }
    public string? Description { get; init; }
}
