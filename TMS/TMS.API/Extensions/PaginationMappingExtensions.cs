using TMS.API.Models.DTOs.Response;
using TMS.Core.Models.Utility;

namespace TMS.API.Extensions;

public static class PaginationMappingExtensions
{
    public static PaginatedResponse<TDto> ToResponse<TItem, TDto>(
        this PaginatedResult<TItem> result,
        Func<TItem, TDto> mapper)
    {
        return new PaginatedResponse<TDto>
        {
            Items = result.Items.Select(mapper),
            Page = result.Page,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount
        };
    }
}
