namespace TMS.API.Models.DTOs.Request;

public record CreateTaskRequest
{
    public required string Subject { get; init; }
    public string? Description { get; init; }
}
