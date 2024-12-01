namespace Expense.Application.DTOs.Reports;

public record ReportDto(
    int Year,
    string MonthName,
    string TotalPrice,
    string TotalCount);
