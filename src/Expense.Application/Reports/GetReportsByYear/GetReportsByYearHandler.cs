using System.Globalization;
using Expense.Application.Abstractions.CQRS;
using Expense.Application.DTOs.Reports;
using Expense.Domain.Entities.Outlays;
using Expense.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expense.Application.Reports.GetReportsByYear;

public class GetReportsByYearHandler(IRepository<Outlay> outlayRepository)
    : IQueryHandler<GetReportsByYearQuery, GetReportsByYearResult>
{
    public async Task<GetReportsByYearResult> Handle(
        GetReportsByYearQuery query,
        CancellationToken cancellationToken)
    {
        var outlayQuery = outlayRepository.GetAll(outlay => outlay.Date.Year == query.Year, null, false);

        var reportDtos = await outlayQuery
            .GroupBy(outlay => outlay.Date.Month)
            .OrderBy(outlayGroup => outlayGroup.Key)
            .Select(outlayGroup => new ReportDto(
                query.Year,
                new CultureInfo("en-US").DateTimeFormat.GetMonthName(outlayGroup.Key),
                $"${outlayGroup.Sum(outlay => outlay.Price)}",
                outlayGroup.LongCount().ToString()))
            .ToListAsync(cancellationToken);

        return new GetReportsByYearResult(reportDtos);
    }
}
