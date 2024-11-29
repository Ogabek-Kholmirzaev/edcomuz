using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Categories;

namespace Expense.Application.Categories.UpdateCategory;

public record UpdateCategoryCommand(CategoryDto Category) : ICommand<UpdateCategoryResult>;