namespace Expense.Blazor.Models;

public record CategoryDto(
    long Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);