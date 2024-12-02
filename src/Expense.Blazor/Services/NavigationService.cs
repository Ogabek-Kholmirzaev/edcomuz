using Expense.Blazor.Models;
using Microsoft.AspNetCore.Components;

namespace Expense.Blazor.Services;

public class NavigationService
{
    private readonly NavigationManager _navigationManager;

    public NavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public void NavigateToUpdateCategory(long categoryId, bool isForced = false)
    {
        _navigationManager.NavigateTo($"/categories/update/{categoryId}", isForced);
    }

    public void NavigateToCategories(int Page = 1, int PageSize = 50, bool isForced = false)
    {
        _navigationManager.NavigateTo($"/categories?page={Page}&pageSize={PageSize}", isForced);
    }

    public void NavigateToCreateCategory(bool isForced = false)
    {
        _navigationManager.NavigateTo("/categories/create", isForced);
    }

    public void NavigateToUpdateOutlay(long outlayId, bool isForced = false)
    {
        _navigationManager.NavigateTo($"/outlays/update/{outlayId}", isForced);
    }

    public void NavigateToOutlays(int Page = 1, int PageSize = 50, bool isForced = false, OutlayFilters filters = null)
    {
        var queryString = $"?page={Page}&pageSize={PageSize}";

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

        _navigationManager.NavigateTo($"/outlays{queryString}", isForced);
    }

    public void NavigateToCreateOutlay(bool isForced = false)
    {
        _navigationManager.NavigateTo("/outlays/create", isForced);
    }
}
