using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Categories;
using Expense.Domain.Entities.Categories;
using Expense.Infrastructure.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Expense.Application.Categories.GetCategories;

public class GetCategoriesHandler(IRepository<Category> categoryRepository)
    : IQueryHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(
        GetCategoriesQuery query,
        CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAll(null!, null!, false)
            .OrderBy(category => category.Id)
            .ToListAsync(cancellationToken);

        var categoriesDto = categories.Adapt<List<CategoryDto>>();

        return new GetCategoriesResult(categoriesDto);
    }
}