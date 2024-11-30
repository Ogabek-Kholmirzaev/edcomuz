using Expense.Application.Abstractions.CQRS;
using Expense.Domain.Entities.Categories;
using Expense.Domain.Entities.Outlays;
using Expense.Infrastructure.Repositories;
using Expense.Infrastructure.UnitOfWorks;

namespace Expense.Application.Outlays.UpdateOutlay;

public class UpdateOutlayHandler(
    IRepository<Outlay> outlayRepository,
    IRepository<Category> categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateOutlayCommand, UpdateOutlayResult>
{
    public async Task<UpdateOutlayResult> Handle(
        UpdateOutlayCommand command,
        CancellationToken cancellationToken)
    {
        await categoryRepository.GetAsync(category =>
            category.Id == command.OutlayDto.CategoryId, null, false, cancellationToken);

        var outlay = await outlayRepository
            .GetAsync(outlay => outlay.Id == command.OutlayDto.Id, null, true, cancellationToken);

        outlay.CategoryId = command.OutlayDto.CategoryId;
        outlay.Date = command.OutlayDto.Date;
        outlay.Price = command.OutlayDto.Price;
        outlay.Comment = command.OutlayDto.Comment;
        outlay.UpdatedAt = DateTime.UtcNow;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateOutlayResult(true);
    }
}