namespace My.DDD.CQRS.Temp6.Domain.SeedWork
{
  public abstract class AggregateRepository<TAggregateRoot>
                  where TAggregateRoot : class, IAggregateRoot
  {
    protected IUnitOfWork<TAggregateRoot> UnitOfWork { get; }

    public AggregateRepository(IUnitOfWork<TAggregateRoot> unitOfWork)
    {
      UnitOfWork = unitOfWork;
    }

    public async Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default)
    {
      await UnitOfWork.AddAsync(aggregateRoot, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken = default)
    {
      await UnitOfWork.AddRangeAsync(aggregateRoots, cancellationToken);
    }

    public async Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
      where TEntity : IEntityBase
    {
      await UnitOfWork.RemoveAsync(entity, cancellationToken);
    }

    public async Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
      where TEntity : IEntityBase
    {
      await UnitOfWork.RemoveRangeAsync(entities, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      await UnitOfWork.SaveChangesAsync(cancellationToken);
    }
  }
}
