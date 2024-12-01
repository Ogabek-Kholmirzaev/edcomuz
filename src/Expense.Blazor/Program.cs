using Expense.Blazor;
using Expense.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUri"] ?? "https://localhost:7165/")
    });

builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<CategoryService>();

await builder.Build().RunAsync();