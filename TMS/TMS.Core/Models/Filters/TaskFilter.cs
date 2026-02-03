namespace TMS.Core.Models.Filters;

public record TaskFilter
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 35;
    public bool? IsCompleted { get; init; }
}
