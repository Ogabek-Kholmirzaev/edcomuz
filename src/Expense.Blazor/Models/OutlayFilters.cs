namespace Expense.Blazor.Models;

public class OutlayFilters
{
    public long? CategoryId { get; set; }
    public string? Comment { get; set; }
    public DateOnly? DateFrom { get; set; }
    public DateOnly? DateTo { get; set; }
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }
}

