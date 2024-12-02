namespace Expense.Blazor.Models.Reports;

public class ReportDto
{
    public int Year { get; set; }
    public string MonthName { get; set; } = default!;
    public string TotalPrice { get; set; } = default!;
    public string TotalCount { get; set; } = default!;
}
