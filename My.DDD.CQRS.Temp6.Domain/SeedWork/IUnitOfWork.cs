using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Domain.SeedWork
{
  public interface IUnitOfWork<TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
  {
    Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default);

    Task AddRangeAsync(IEnumerable<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken = default);

    Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
      where TEntity : IEntityBase;

    Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
      where TEntity : IEntityBase;

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
  }

}
