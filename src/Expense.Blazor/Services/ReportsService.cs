using System.Net.Http.Json;
using Expense.Blazor.Models.Reports;

namespace Expense.Blazor.Services;

public class ReportsService
{
    private readonly HttpClient _httpClient;

    public ReportsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetReportsByYearResult?> GetReportsByYearAsync(int year)
    {
        return await _httpClient.GetFromJsonAsync<GetReportsByYearResult>($"api/reports/year/{year}");
    }
}
