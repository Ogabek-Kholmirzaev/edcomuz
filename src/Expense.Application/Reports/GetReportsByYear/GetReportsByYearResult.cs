using Expense.Application.DTOs.Reports;

namespace Expense.Application.Reports.GetReportsByYear;

public record GetReportsByYearResult(IEnumerable<ReportDto> Report);
