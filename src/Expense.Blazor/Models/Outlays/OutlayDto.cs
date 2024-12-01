using Expense.Blazor.Models.Categories;

namespace Expense.Blazor.Models.Outlays;

public class OutlayDto
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public DateOnly Date { get; set; }
    public decimal Price { get; set; }
    public string? Comment { get; set; }
    public CategoryDto? Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}