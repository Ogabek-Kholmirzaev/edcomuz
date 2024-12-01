namespace Expense.Blazor.Models.Categories;

public record GetCategoriesResult(PaginatedResult<CategoryDto> Categories);