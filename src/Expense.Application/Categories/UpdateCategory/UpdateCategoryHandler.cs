using Expense.Application.Abstractions.CQRS;
using Expense.Domain.Entities.Categories;
using Expense.Infrastructure.Repositories;
using Expense.Infrastructure.UnitOfWorks;

namespace Expense.Application.Categories.UpdateCategory;

public class UpdateCategoryHandler(
    IRepository<Category> categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCategoryCommand, UpdateCategoryResult>
{
    public async Task<UpdateCategoryResult> Handle(
        UpdateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var category = await categoryRepository
            .GetAsync(category => category.Id == command.Category.Id, null, true, cancellationToken);

        category.Name = command.Category.Name;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateCategoryResult(true);
    }
}