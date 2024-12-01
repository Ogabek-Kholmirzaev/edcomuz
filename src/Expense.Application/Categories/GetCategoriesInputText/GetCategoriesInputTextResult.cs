using Expense.Application.DTOs.Categories;

namespace Expense.Application.Categories.GetCategoriesInputText;

public  record GetCategoriesInputTextResult(IEnumerable<CategoryInputTextDto> CategoriesInputText);
