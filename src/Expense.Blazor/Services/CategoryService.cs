using System.Net.Http.Json;
using Expense.Blazor.Models.Categories;

namespace Expense.Blazor.Services;

public class CategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<GetCategoriesResult?> GetCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<GetCategoriesResult>("api/categories");
    }

    public async Task<GetCategoryResult?> GetCategoryByIdAsync(long id)
    {
        return await _httpClient.GetFromJsonAsync<GetCategoryResult>($"api/categories/{id}");
    }

    public async Task<bool> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/categories", categoryDto);
        
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCategoryAsync(long id, CategoryDto categoryDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/categories/{id}", categoryDto);
        
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCategoryAsync(long id)
    {
        var response = await _httpClient.DeleteAsync($"api/categories/{id}");
        
        return response.IsSuccessStatusCode;
    }
}