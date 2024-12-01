using System.ComponentModel.DataAnnotations;

namespace Expense.Blazor.Models.Categories;

public class CategoryDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Category name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exeed 100 characters.")]
    public string Name { get; set; } = default!;

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}