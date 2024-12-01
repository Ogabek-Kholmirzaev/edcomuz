using Expense.Blazor.Models.Categories;

namespace Expense.Blazor.Models;

public record OutlayDto(
    long Id,
    long CategoryId,
    DateOnly Date,
    decimal Price,
    string? Comment,
    CategoryDto? Category,
    DateTime CreatedAt,
    DateTime? UpdatedAt);