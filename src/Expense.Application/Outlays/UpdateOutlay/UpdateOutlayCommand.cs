using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Outlays;

namespace Expense.Application.Outlays.UpdateOutlay;

public record UpdateOutlayCommand(OutlayDto OutlayDto) : ICommand<UpdateOutlayResult>;