using System.Linq.Expressions;
using Expense.Domain.Entities.Abstractions;
using Expense.Infrastructure.Data;
using Expense.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Expense.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbSet;

    public Repository(OutlayDbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, string[] includes = null, bool isTracking = true)
    {
        var query = expression == null
            ? _dbSet
            : _dbSet.Where(expression);

        if (includes?.Length > 0)
        {
            foreach (var include in includes)
            {
                if (string.IsNullOrWhiteSpace(include))
                {
                    query = query.Include(include);
                }
            }
        }

        if (!isTracking)
        {
            query = query.AsNoTracking().AsSplitQuery();
        }

        return query;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null, bool isTracking = true, CancellationToken cancellationToken = default)
    {
        var entity = await GetAll(expression, includes, isTracking)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(TEntity).Name, GetPropertyName(expression));

        return entity;
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
    
    private string GetPropertyName(Expression<Func<TEntity, bool>> expression)
    {
        if (expression.Body is BinaryExpression binaryExpression)
        {
            if (binaryExpression.Left is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }
        }

        return string.Empty;
    }
}