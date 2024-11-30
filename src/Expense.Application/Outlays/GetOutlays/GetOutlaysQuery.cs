using Expense.Application.Abstractions.CQRS;
using Expense.Application.Pagination;

namespace Expense.Application.Outlays.GetOutlays;

public record GetOutlaysQuery(PaginationRequest Request) : IQuery<GetOutlaysResult>;