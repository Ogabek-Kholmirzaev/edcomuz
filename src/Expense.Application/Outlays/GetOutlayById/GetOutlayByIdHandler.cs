using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Outlays;
using Expense.Domain.Entities.Outlays;
using Expense.Infrastructure.Repositories;
using Mapster;

namespace Expense.Application.Outlays.GetOutlayById;

public class GetOutlayById(IRepository<Outlay> outlayRepository)
    : IQueryHandler<GetOutlayByIdQuery, GetOutlayByIdResult>
{
    public async Task<GetOutlayByIdResult> Handle(
        GetOutlayByIdQuery command,
        CancellationToken cancellationToken)
    {
        var outlay = await outlayRepository
            .GetAsync(outlay => outlay.Id == command.Id, null, false, cancellationToken);

        var outlayDto = outlay.Adapt<OutlayDto>();

        return new GetOutlayByIdResult(outlayDto);
    }
}