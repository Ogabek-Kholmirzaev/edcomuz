using Microsoft.JSInterop;

namespace Expense.Blazor.Services;

public class ToastrService
{
    private readonly IJSRuntime _jsRuntime;

    public ToastrService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ShowSuccess(string message, string title = "Success")
    {
        await _jsRuntime.InvokeVoidAsync("toastr.success", message, title);
    }

    public async Task ShowError(string message, string title = "Error")
    {
        await _jsRuntime.InvokeVoidAsync("toastr.error", message, title);
    }

    public async Task ShowWarning(string message, string title = "Warning")
    {
        await _jsRuntime.InvokeVoidAsync("toastr.warning", message, title);
    }

    public async Task ShowInfo(string message, string title = "Info")
    {
        await _jsRuntime.InvokeVoidAsync("toastr.info", message, title);
    }
}
