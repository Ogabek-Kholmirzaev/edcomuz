using Microsoft.Extensions.DependencyInjection;

namespace Expense.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly));
        
        return services;
    }
}