using Microsoft.EntityFrameworkCore;
using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.DBAccess
{

  public class UnitOfWork<TDbContext, TAggregateRoot> : IUnitOfWork<TAggregateRoot>
                          where TDbContext : DbContext
                          where TAggregateRoot : IAggregateRoot
  {
    protected TDbContext DbContext { get; }

    public UnitOfWork(TDbContext dbContext)
    {
      DbContext = dbContext;
    }

    public async Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default)
    {
      await DbContext.AddAsync(aggregateRoot, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken = default)
    {
      await DbContext.AddRangeAsync(aggregateRoots, cancellationToken);
    }

    public Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
      where TEntity : IEntityBase
    {
      DbContext.Remove(entity);

      return Task.CompletedTask;
    }

    public Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
      where TEntity : IEntityBase
    {
      DbContext.RemoveRange(entities);

      return Task.CompletedTask;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      await DbContext.SaveChangesAsync(cancellationToken);
    }
  }
}