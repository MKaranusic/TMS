namespace TMS.API.Models.DTOs.Response;

public record TaskDto
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
    public object Status { get; init; }
}
