namespace Expense.Application.DTOs.Categories;

public record CategoryDto(
    long Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);