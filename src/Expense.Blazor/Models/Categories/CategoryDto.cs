namespace Expense.Blazor.Models.Categories;

public record CategoryDto(
    long Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);