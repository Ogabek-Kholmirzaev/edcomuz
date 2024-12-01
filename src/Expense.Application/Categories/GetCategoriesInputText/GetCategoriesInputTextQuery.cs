using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Categories.GetCategoriesInputText;

public record GetCategoriesInputTextQuery : IQuery<GetCategoriesInputTextResult>;
