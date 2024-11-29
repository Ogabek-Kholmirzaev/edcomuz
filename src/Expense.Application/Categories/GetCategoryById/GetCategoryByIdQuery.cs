using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Categories.GetCategoryById;

public record GetCategoryByIdQuery(ulong Id) : IQuery<GetCategoryByIdResult>;