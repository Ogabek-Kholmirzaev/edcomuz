using Expense.Domain.Entities.Abstractions;
using Expense.Domain.Entities.Categories;

namespace Expense.Domain.Entities.Outlays;

public sealed class Outlay : Entity
{
    public long CategoryId { get; set; }
    public DateOnly Date { get; set; }
    public decimal Price { get; set; }
    public string? Comment { get; set; }

    public Category Category { get; set; } = default!;
}