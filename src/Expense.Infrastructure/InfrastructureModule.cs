using Expense.Infrastructure.Data;
using Expense.Infrastructure.Repositories;
using Expense.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expense.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new ArgumentNullException("Database connection string is null");

        services.AddDbContext<OutlayDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
    
    public static IApplicationBuilder  UseInfrastructureModule(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<OutlayDbContext>();
        
        dbContext.Database.MigrateAsync().GetAwaiter().GetResult();
        
        return app;
    }
}