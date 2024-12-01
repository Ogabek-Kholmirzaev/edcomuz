namespace Expense.Blazor.Models.Outlays;

public class GetOutlaysResult
{

    public PaginatedResult<OutlayDto> Outlays { get; set; } = default!;
}
