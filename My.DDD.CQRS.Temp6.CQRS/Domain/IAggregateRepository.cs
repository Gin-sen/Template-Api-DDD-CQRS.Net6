using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS.Domain
{
  public interface IAggregateRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
  {
    Task SaveChangesAsync(CancellationToken cancellationToken);

    Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
      where TEntity : IEntityBase;

    Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken)

      where TEntity : IEntityBase;
    void Remove<TEntity>(TEntity entity) where TEntity : IEntityBase;

    void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntityBase;
  }

}
