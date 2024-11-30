using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Categories;
using Expense.Application.Pagination;
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
        var categoriesQuery = categoryRepository.GetAll(null!, null!, false);

        var totalCount = await categoriesQuery.LongCountAsync(cancellationToken);
        var pageIndex = query.Request.PageIndex;
        var pageSize = query.Request.PageSize;

        var categories = await categoriesQuery
            .OrderBy(category => category.Id)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        
        var categoriesDto = categories.Adapt<List<CategoryDto>>();

        var paginatedResult = new PaginatedResult<CategoryDto>(
            pageIndex,
            pageSize,
            totalCount,
            categoriesDto);

        return new GetCategoriesResult(paginatedResult);
    }
}