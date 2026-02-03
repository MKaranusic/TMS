namespace TMS.Core.Models;

public record TaskItem
{
    public int Id { get; init; }
    public string Subject { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsCompleted { get; init; }
}
