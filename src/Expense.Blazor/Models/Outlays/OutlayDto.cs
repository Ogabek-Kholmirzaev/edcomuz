using System.ComponentModel.DataAnnotations;
using Expense.Blazor.Models.Categories;

namespace Expense.Blazor.Models.Outlays;

public class OutlayDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public long CategoryId { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public DateOnly Date { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }

    public string? Comment { get; set; }
    public CategoryDto? Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}