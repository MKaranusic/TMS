namespace TMS.API.Models.DTOs.Request;

public record UpdateTaskRequest
{
    public required string Subject { get; init; }
    public string? Description { get; init; }
    public bool IsCompleted { get; init; }
}
