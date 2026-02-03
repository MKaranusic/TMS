namespace TMS.API.Models.DTOs.Response;

public record TaskDto
{
    public int Id { get; init; }
    public string Subject { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsCompleted { get; init; }
}
