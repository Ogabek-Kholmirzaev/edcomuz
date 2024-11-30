using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Outlays;
using Expense.Domain.Entities.Outlays;
using Expense.Infrastructure.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Expense.Application.Outlays.GetOutlays;

public class GetOutlaysHandler(IRepository<Outlay> outlayRepository)
    : IQueryHandler<GetOutlaysQuery, GetOutlaysResult>
{
    public async Task<GetOutlaysResult> Handle(
        GetOutlaysQuery request,
        CancellationToken cancellationToken)
    {
        var outlays = await outlayRepository.GetAll(null, ["Category"], false)
            .OrderBy(outlay => outlay.Id)
            .ToListAsync(cancellationToken);

        var outlaysDto = outlays.Adapt<List<OutlayDto>>();

        return new GetOutlaysResult(outlaysDto);
    }
}