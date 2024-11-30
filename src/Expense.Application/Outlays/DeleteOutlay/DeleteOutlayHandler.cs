using Expense.Application.Abstractions.CQRS;
using Expense.Domain.Entities.Outlays;
using Expense.Infrastructure.Repositories;
using Expense.Infrastructure.UnitOfWorks;

namespace Expense.Application.Outlays.DeleteOutlay;

public class DeleteOutlayHandler(
    IRepository<Outlay> outlayRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteOutlayCommand, DeleteOutlayResult>
{
    public async Task<DeleteOutlayResult> Handle(
        DeleteOutlayCommand command,
        CancellationToken cancellationToken)
    {
        var outlay = await outlayRepository
            .GetAsync(outlay => outlay.Id == command.Id, null, true, cancellationToken);
        
        outlayRepository.Delete(outlay);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteOutlayResult(true);
    }
}