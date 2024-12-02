namespace Expense.Blazor.Models.Reports;

public class GetReportsByYearResult
{
    public IEnumerable<ReportDto> Report { get; set; } = default!;
}
