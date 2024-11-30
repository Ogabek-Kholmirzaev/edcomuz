using Expense.Application.DTOs.Categories;

namespace Expense.Application.DTOs.Outlays;

public record OutlayDto(
    long Id,
    long CategoryId,
    DateOnly Date,
    decimal Price,
    string? Comment,
    CategoryDto Category,
    DateTime CreatedAt,
    DateTime? UpdatedAt);