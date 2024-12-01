using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Categories;
using Expense.Domain.Entities.Categories;
using Expense.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expense.Application.Categories.GetCategoriesInputText;

public class GetCategoriesInputTextHandler(
    IRepository<Category> categoryRespository)
    : IQueryHandler<GetCategoriesInputTextQuery, GetCategoriesInputTextResult>
{
    public async Task<GetCategoriesInputTextResult> Handle(
        GetCategoriesInputTextQuery request,
        CancellationToken cancellationToken)
    {
        var categoryInputTextDtos = await (categoryRespository.GetAll(null, null, false)
            .Select(category => new CategoryInputTextDto(category.Id, category.Name)))
            .ToListAsync(cancellationToken);

        return new GetCategoriesInputTextResult(categoryInputTextDtos);
    }
}
