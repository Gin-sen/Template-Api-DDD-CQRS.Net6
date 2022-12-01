using My.DDD.CQRS.Temp6.AzureStorage.Tables;
using My.DDD.CQRS.Temp6.AzureTables.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.AzureTables.Repositories
{
  public class ExempleRepository : AzureTableContext<ExempleEntity>, IExempleRepository
  {
    public ExempleRepository(string tableName, string storageConnectionString)
      : base(tableName, storageConnectionString) { }


    public async Task<ExempleEntity> GetExempleAsync(string exempleString1, string exempleString2)
    {
      return await GetEntityAsync($"PartitionKey eq {exempleString1} and RowKey eq {exempleString2}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task AddOrUpdateExempleAsync(string exempleString1, string exempleString2)
    {
      ExempleEntity exemple = await GetExempleAsync(exempleString1, exempleString2);
      if (exemple != null)
      {
        exemple.Increment++;
        await InsertOrUpdateEntityAsync(exemple);
      }
      else
      {
        exemple = new ExempleEntity(exempleString1, exempleString2);
        await InsertEntityAsync(exemple);
      }

    }

    public async Task<IEnumerable<ExempleEntity>> GetAllAsync()
    {
      return await GetEntitiesAsync($"PartitionKey ne ''");
    }
  }
}
