using System.Linq.Expressions;
using Expense.Domain.Entities.Abstractions;

namespace Expense.Infrastructure.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> GetAll(
        Expression<Func<TEntity, bool>> expression,
        string[] includes = null,
        bool isTracking = true);

    Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes = null,
        bool isTracking = true,
        CancellationToken cancellationToken = default);

    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}