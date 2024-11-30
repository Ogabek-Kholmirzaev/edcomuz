using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Outlays;

namespace Expense.Application.Outlays.CreateOutlay;

public record CreateOutlayCommand(OutlayDto OutlayDto) : ICommand<CreateOutlayResult>;