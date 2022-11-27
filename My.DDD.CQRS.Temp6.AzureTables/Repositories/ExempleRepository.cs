using My.DDD.CQRS.Temp6.AzureTables.Entities;
using My.DDD.CQRS.Temp6.AzureTables.Tables;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.AzureTables.Repositories
{
  public class ExempleRepository : IExempleRepository
  {
    private readonly IExempleTable _exempleTable;

    public ExempleRepository(IExempleTable exempleTable)
    {
      _exempleTable = exempleTable;
    }

    public async Task AddAsync(string exemple, CancellationToken cancellationToken)
    {
      await _exempleTable.AddOrUpdateExempleAsync(exemple, exemple);
    }

    public Task AddRangeAsync(IEnumerable<Exemple> entities, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Exemple>> GetAllAsync(CancellationToken cancellationToken)
    {
      var resultRequest = await _exempleTable.GetAllAsync();
      var length = resultRequest.Count();
      var result = new List<Exemple>();
      foreach (var element in resultRequest) {
        result.Add(new Exemple(element.PartitionKey, element.RowKey, element.Increment, element.Timestamp));
      }
      return result.AsEnumerable();
    }

    public async Task<Exemple> GetAsync(string exemple, CancellationToken cancellationToken)
    {
      var result = await _exempleTable.GetExempleAsync(exemple, exemple);
      return new Exemple(result.PartitionKey, result.RowKey, result.Increment, result.Timestamp);
    }

    public void Remove(Exemple entity)
    {
      throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<Exemple> entities)
    {
      throw new NotImplementedException();
    }
  }
}
