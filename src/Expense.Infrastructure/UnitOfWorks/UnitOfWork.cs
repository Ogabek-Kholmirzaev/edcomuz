using Expense.Infrastructure.Data;

namespace Expense.Infrastructure.UnitOfWorks;

public class UnitOfWork(OutlayDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}