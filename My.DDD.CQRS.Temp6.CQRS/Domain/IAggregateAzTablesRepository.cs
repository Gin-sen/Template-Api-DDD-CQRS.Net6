using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS.Domain
{
  public interface IAggregateAzTablesRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
  {

    Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
      where TEntity : IEntityBase;

    Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken)

      where TEntity : IEntityBase;
    void Remove<TEntity>(TEntity entity) where TEntity : IEntityBase;

    void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntityBase;
  }

}
