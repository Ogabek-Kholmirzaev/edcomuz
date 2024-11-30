using Expense.Application.Abstractions.CQRS;
using Expense.Domain.Entities.Categories;
using Expense.Infrastructure.Repositories;
using Expense.Infrastructure.UnitOfWorks;

namespace Expense.Application.Categories.DeleteCategory;

public class DeleteCategoryHandler(
    IRepository<Category> categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteCategoryCommand, DeleteCategoryResult>
{
    public async Task<DeleteCategoryResult> Handle(
        DeleteCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var category = await categoryRepository
            .GetAsync(category => category.Id == command.Id, null, true, cancellationToken);
        
        categoryRepository.Delete(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteCategoryResult(true);
    }
}