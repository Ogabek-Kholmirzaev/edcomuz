using Expense.Application.Abstractions.CQRS;
using Expense.Domain.Entities.Categories;
using Expense.Infrastructure.Repositories;
using Expense.Infrastructure.UnitOfWorks;

namespace Expense.Application.Categories.CreateCategory;

public class CreateCategoryHandler(
    IRepository<Category> categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
{
    public async Task<CreateCategoryResult> Handle(
        CreateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = command.Category.Name
        };
        
        categoryRepository.Add(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateCategoryResult(category.Id);
    }
}