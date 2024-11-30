using Expense.Application.DTOs.Outlays;
using Expense.Application.Pagination;

namespace Expense.Application.Outlays.GetOutlays;

public record GetOutlaysResult(PaginatedResult<OutlayDto> Outlays);