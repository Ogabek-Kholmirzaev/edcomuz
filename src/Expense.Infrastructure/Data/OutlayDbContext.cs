using Expense.Domain.Entities.Categories;
using Expense.Domain.Entities.Outlays;
using Microsoft.EntityFrameworkCore;

namespace Expense.Infrastructure.Data;

public class OutlayDbContext : DbContext
{
    public OutlayDbContext(DbContextOptions<OutlayDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Outlay> Expenses => Set<Outlay>();
}
