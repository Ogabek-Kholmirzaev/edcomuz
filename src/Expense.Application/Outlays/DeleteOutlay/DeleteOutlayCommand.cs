using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Outlays.DeleteOutlay;

public record DeleteOutlayCommand(long Id) : ICommand<DeleteOutlayResult>;