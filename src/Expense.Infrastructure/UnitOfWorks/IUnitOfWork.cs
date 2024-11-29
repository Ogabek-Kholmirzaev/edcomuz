namespace Expense.Infrastructure.UnitOfWorks;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}