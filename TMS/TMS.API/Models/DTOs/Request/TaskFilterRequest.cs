namespace TMS.API.Models.DTOs.Request;

public record TaskFilterRequest
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public bool? IsCompleted { get; init; }
}
