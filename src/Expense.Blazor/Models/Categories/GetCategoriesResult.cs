namespace Expense.Blazor.Models.Categories;

public class GetCategoriesResult
{
    public PaginatedResult<CategoryDto> Categories { get; set; } = default!;
}