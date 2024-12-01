namespace Expense.Blazor.Models.Categories;

public class CategoryDto
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}