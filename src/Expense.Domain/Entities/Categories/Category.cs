using Expense.Domain.Entities.Abstractions;

namespace Expense.Domain.Entities.Categories;

public sealed class Category : Entity
{
    public string Name { get; set; } = default!;
}