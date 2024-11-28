using Expense.Domain.Entities.Abstractions;

namespace Expense.Domain.Entities.Categories;

public sealed class Category : Entity<ulong>
{
    public string Name { get; set; } = default!;
}