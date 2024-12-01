using Expense.Application.Abstractions.CQRS;

namespace Expense.Application.Reports.GetReportsByYear;

public record GetReportsByYearQuery(int Year) : IQuery<GetReportsByYearResult>;
