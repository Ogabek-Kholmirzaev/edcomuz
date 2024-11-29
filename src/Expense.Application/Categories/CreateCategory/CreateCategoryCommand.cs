using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Categories;

namespace Expense.Application.Categories.CreateCategory;

public record CreateCategoryCommand(CategoryDto Category) : ICommand<CreateCategoryResult>;