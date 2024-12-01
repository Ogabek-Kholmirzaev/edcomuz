using Expense.Blazor;
using Expense.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7165/") });
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<NavigationService>();
builder.Services.AddScoped<ToastrService>();

await builder.Build().RunAsync();
