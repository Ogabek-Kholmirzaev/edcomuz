using Expense.Infrastructure.Data;
using Expense.Infrastructure.Repositories;
using Expense.Infrastructure.UnitOfWorks;
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
}