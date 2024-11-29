namespace Expense.Domain.Entities.Abstractions;

public abstract class Entity
{
    public ulong Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}