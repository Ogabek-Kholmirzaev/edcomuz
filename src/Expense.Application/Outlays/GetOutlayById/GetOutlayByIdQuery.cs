using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Outlays.GetOutlayById;

public record GetOutlayByIdQuery(long Id) : IQuery<GetOutlayByIdResult>;