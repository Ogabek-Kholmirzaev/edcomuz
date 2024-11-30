using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Categories.DeleteCategory;

public record DeleteCategoryCommand(long Id) : ICommand<DeleteCategoryResult>;