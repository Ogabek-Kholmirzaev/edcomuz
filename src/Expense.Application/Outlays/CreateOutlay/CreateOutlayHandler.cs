using Expense.Application.Abstractions.CQRS;
using Expense.Domain.Entities.Categories;
using Expense.Domain.Entities.Outlays;
using Expense.Infrastructure.Repositories;
using Expense.Infrastructure.UnitOfWorks;

namespace Expense.Application.Outlays.CreateOutlay;

public class CreateOutlayHandler(
    IRepository<Outlay> outlayRepository,
    IRepository<Category> categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateOutlayCommand, CreateOutlayResult>
{
    public async Task<CreateOutlayResult> Handle(
        CreateOutlayCommand command,
        CancellationToken cancellationToken)
    {
         await categoryRepository.GetAsync(category =>
             category.Id == command.OutlayDto.CategoryId, null, false, cancellationToken);

        var outlay = new Outlay
        {
            CategoryId = command.OutlayDto.CategoryId,
            Date = command.OutlayDto.Date,
            Price = command.OutlayDto.Price,
            Comment = command.OutlayDto.Comment
        };
        
        outlayRepository.Add(outlay);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateOutlayResult(outlay.Id);
    }
}