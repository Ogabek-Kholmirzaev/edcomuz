using Expense.Application.Abstractions.CQRS;
using Expense.Application.Pagination;

namespace Expense.Application.Categories.GetCategories;

public record GetCategoriesQuery(PaginationRequest Request) : IQuery<GetCategoriesResult>;