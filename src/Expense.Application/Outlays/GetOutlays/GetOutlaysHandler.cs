using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Outlays;
using Expense.Application.Pagination;
using Expense.Domain.Entities.Outlays;
using Expense.Infrastructure.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Expense.Application.Outlays.GetOutlays;

public class GetOutlaysHandler(IRepository<Outlay> outlayRepository)
    : IQueryHandler<GetOutlaysQuery, GetOutlaysResult>
{
    public async Task<GetOutlaysResult> Handle(
        GetOutlaysQuery query,
        CancellationToken cancellationToken)
    {
        
        var outlaysQuery = outlayRepository.GetAll(null, null, false);

        var totalCount = await outlaysQuery.LongCountAsync(cancellationToken);
        var pageIndex = query.Request.PageIndex;
        var pageSize = query.Request.PageSize;
        
        var outlays = await outlaysQuery
            .Include(outlay => outlay.Category)
            .OrderBy(outlay => outlay.Id)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToListAsync(cancellationToken); 
        
        var outlaysDto = outlays.Adapt<List<OutlayDto>>();

        var paginatedResult = new PaginatedResult<OutlayDto>(
            pageIndex,
            pageSize,
            totalCount,
            outlaysDto);

        return new GetOutlaysResult(paginatedResult);
    }
}