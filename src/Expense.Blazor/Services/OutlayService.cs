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

    public async Task<GetOutlaysResult?> GetOutlaysAsync(int PageIndex = 1, int PageSize = 50)
    {
        return await _httpClient
            .GetFromJsonAsync<GetOutlaysResult>($"api/outlays?PageIndex={PageIndex}&PageSize={PageSize}");
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
