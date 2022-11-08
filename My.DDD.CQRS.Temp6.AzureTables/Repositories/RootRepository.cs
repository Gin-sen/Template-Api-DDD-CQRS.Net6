using My.DDD.CQRS.Temp6.AzureTables.Entities;
using My.DDD.CQRS.Temp6.AzureTables.Tables;
using My.DDD.CQRS.Temp6.CQRS.Domain;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.AzureTables.Repositories
{
  public class RootRepository : IRootRepository
  {
    private readonly IExempleTable _exempleTable;

    public RootRepository(IExempleTable exempleTable)
    {
      _exempleTable = exempleTable;
    }

    public Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : IEntityBase
    {
      throw new NotImplementedException();
    }

    public Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken) where TEntity : IEntityBase
    {
      throw new NotImplementedException();
    }

    public async Task<Root?> Get()
    {
      int i = 0;
      if (_exempleTable == null)
        return null;
      var exempleEntities = await _exempleTable.GetAllAsync();
      var exemples = new Exemple[exempleEntities.Count()];
      foreach (var exempleEntity in exempleEntities)
      {
        exemples[i] = new Exemple(exempleEntity.PartitionKey, exempleEntity.RowKey, exempleEntity.Increment, exempleEntity.Timestamp);
        i++;
      }
      var result = new Root(exemples.AsQueryable());
      return result;
    }

    public void Remove<TEntity>(TEntity entity) where TEntity : IEntityBase
    {
      throw new NotImplementedException();
    }

    public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntityBase
    {
      throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
