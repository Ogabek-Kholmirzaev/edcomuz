using Expense.Application.DTOs.Categories;

namespace Expense.Application.Categories.GetCategories;

public record GetCategoriesResult(IEnumerable<CategoryDto> Categories);