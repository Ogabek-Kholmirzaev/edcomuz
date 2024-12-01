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

    public void NavigateToCategories(bool isForced = false)
    {
        _navigationManager.NavigateTo("/categories", isForced);
    }

    public void NavigateToCreateCategory(bool isForced = false)
    {
        _navigationManager.NavigateTo("/categories/create", isForced);
    }

    public void NavigateToUpdateOutlay(long outlayId, bool isForced = false)
    {
        _navigationManager.NavigateTo($"/outlays/update/{outlayId}", isForced);
    }

    public void NavigateToOutlays(int Page, int PageSize, bool isForced = false)
    {
        _navigationManager.NavigateTo($"/outlays?page={Page}&pageSize={PageSize}", isForced);
    }

    public void NavigateToCreateOutlay(bool isForced = false)
    {
        _navigationManager.NavigateTo("/outlays/create", isForced);
    }
}
