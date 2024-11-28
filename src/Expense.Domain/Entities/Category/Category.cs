using Expense.Domain.Entities.Abstractions;

namespace Expense.Domain.Entities.Category;

public sealed class Category : Entity<ulong>
{
    public string Name { get; set; } = default!;
}