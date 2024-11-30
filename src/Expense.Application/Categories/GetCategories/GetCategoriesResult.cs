using Expense.Application.DTOs.Categories;
using Expense.Application.Pagination;

namespace Expense.Application.Categories.GetCategories;

public record GetCategoriesResult(PaginatedResult<CategoryDto> Categories);