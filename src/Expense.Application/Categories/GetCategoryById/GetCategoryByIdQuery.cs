using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Categories.GetCategoryById;

public record GetCategoryByIdQuery(long Id) : IQuery<GetCategoryByIdResult>;