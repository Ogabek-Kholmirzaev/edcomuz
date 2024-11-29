using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Categories;
using Expense.Domain.Entities.Categories;
using Expense.Infrastructure.Repositories;
using Mapster;

namespace Expense.Application.Categories.GetCategoryById;

public class GetCategoryByIdHandler(IRepository<Category> categoryRepository)
    : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
{
    public async Task<GetCategoryByIdResult> Handle(
        GetCategoryByIdQuery query,
        CancellationToken cancellationToken)
    {
        var category = await categoryRepository
            .GetAsync(category => category.Id == query.Id, null, false, cancellationToken);

        var categoryDto = category.Adapt<CategoryDto>();

        return new GetCategoryByIdResult(categoryDto);
    }
}