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

    public Root Get()
    {
      throw new NotImplementedException();
      //var result = new Root();
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
