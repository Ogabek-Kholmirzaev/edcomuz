using Microsoft.AspNetCore.Components;

namespace Expense.Blazor.Services;

public class NavigationService
{
    private readonly NavigationManager _navigationManager;

    public NavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public void NavigateToUpdateCategory(long categoryId)
    {
        _navigationManager.NavigateTo($"/categories/update/{categoryId}");
    }

    public void NavigateToCategories()
    {
        _navigationManager.NavigateTo("/categories");
    }
}
