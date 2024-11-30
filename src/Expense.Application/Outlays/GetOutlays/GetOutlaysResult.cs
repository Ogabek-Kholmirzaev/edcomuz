using Expense.Application.DTOs.Outlays;

namespace Expense.Application.Outlays.GetOutlays;

public record GetOutlaysResult(IEnumerable<OutlayDto> Outlays);