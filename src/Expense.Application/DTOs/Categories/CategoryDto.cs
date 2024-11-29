namespace Expense.Application.DTOs.Categories;

public record CategoryDto(
    ulong Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);