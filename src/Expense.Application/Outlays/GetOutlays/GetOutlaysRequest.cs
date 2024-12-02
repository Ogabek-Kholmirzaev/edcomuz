using Expense.Application.Pagination;

namespace Expense.Application.Outlays.GetOutlays;

public record GetOutlaysRequest(
    long? CategoryId,
    string? Comment,
    DateOnly? DateFrom,
    DateOnly? DateTo,
    decimal? PriceFrom,
    decimal? PriceTo) : PaginationRequest;
