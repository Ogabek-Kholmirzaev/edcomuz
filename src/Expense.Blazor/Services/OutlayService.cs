using Expense.Blazor.Models;
using Expense.Blazor.Models.Outlays;
using System.Net.Http.Json;

namespace Expense.Blazor.Services;

public class OutlayService
{
    private readonly HttpClient _httpClient;

    public OutlayService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetOutlaysResult?> GetOutlaysAsync(int PageIndex = 1, int PageSize = 50, OutlayFilters filters = null)
    {
        var queryString = $"?page={PageIndex}&pageSize={PageSize}";

        if (filters != null)
        {
            if (filters.CategoryId.HasValue)
            {
                queryString += $"&categoryId={filters.CategoryId}";
            }

            if (!string.IsNullOrWhiteSpace(filters.Comment))
            {
                queryString += $"&comment={filters.Comment}";
            }

            if (filters.DateFrom.HasValue)
            {
                queryString += $"&dateFrom={filters.DateFrom}";
            }

            if (filters.DateTo.HasValue)
            {
                queryString += $"&dateTo={filters.DateTo}";
            }

            if (filters.PriceFrom.HasValue)
            {
                queryString += $"&priceFrom={filters.PriceFrom.Value}";
            }

            if (filters.PriceTo.HasValue)
            {
                queryString += $"&priceTo={filters.PriceTo.Value}";
            }
        }

        return await _httpClient
            .GetFromJsonAsync<GetOutlaysResult>($"api/outlays{queryString}");
    }

    public async Task<GetOutlayResult?> GetOutlayByIdAsync(long id)
    {
        return await _httpClient.GetFromJsonAsync<GetOutlayResult>($"api/outlays/{id}");
    }

    public async Task<bool> CreateOutlayAsync(OutlayDto outlayDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/outlays", outlayDto);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateOutlayAsync(long id, OutlayDto outlayDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/outlays/{id}", outlayDto);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteOutlayAsync(long id)
    {
        var response = await _httpClient.DeleteAsync($"api/outlays/{id}");

        return response.IsSuccessStatusCode;
    }
}
