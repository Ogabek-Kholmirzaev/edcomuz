using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Categories.GetCategories;

public record GetCategoriesQuery() : IQuery<GetCategoriesResult>;