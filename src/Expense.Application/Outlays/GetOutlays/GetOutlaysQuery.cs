using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Outlays.GetOutlays;

public record GetOutlaysQuery : IQuery<GetOutlaysResult>;