using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.AzureStorage.Tables
{
  public class AzureTableContext<T> where T : class, ITableEntity, new()
  {

    /// <summary>
    /// Chaine de connexion vers la table 
    /// </summary>
    private readonly string _storageConnectionString;
    /// <summary>
    /// Nom de la table Azure
    /// </summary>
    private readonly string _tableName;


    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="storageConnectionString"></param>
    public AzureTableContext(string tableName, string storageConnectionString)
    {
      _storageConnectionString = storageConnectionString;
      _tableName = tableName;
    }

    protected TableClient GetTableClient()
    {
      var serviceClient = new TableServiceClient(_storageConnectionString);
      var tableClient = serviceClient.GetTableClient(_tableName);
      tableClient.CreateIfNotExists();
      return tableClient;
    }

    protected async Task InsertOrUpdateEntityAsync(T tableEntity)
    {
      var tableClient = GetTableClient();
      var res = await tableClient.UpsertEntityAsync(tableEntity);
      Console.WriteLine(res);
    }

    protected async Task InsertEntityAsync(T tableEntity)
    {
      var tableClient = GetTableClient();
      var res = await tableClient.AddEntityAsync(tableEntity);
    }

    protected async Task<T> GetEntityAsync(FormattableString filter)
    {
      var tableClient = GetTableClient();
      AsyncPageable<T> result = tableClient.QueryAsync<T>(TableClient.CreateQueryFilter(filter));

      await foreach (var item in result)
      {
        return item;
      }

      return null;
    }

    protected async Task<IEnumerable<T>> GetEntitiesAsync(FormattableString filter)
    {
      var tableClient = GetTableClient();
      AsyncPageable<T> result = tableClient.QueryAsync<T>(TableClient.CreateQueryFilter(filter));
      List<T> list = new List<T>();
      await foreach (var item in result)
      {
        list.Add(item);
      }

      return list.AsEnumerable();
    }


    protected T GetEntity(FormattableString filter)
    {
      var tableClient = GetTableClient();
      Pageable<T> result = tableClient.Query<T>(TableClient.CreateQueryFilter(filter));
      return result.FirstOrDefault();
    }

    protected IEnumerable<T> GetEntities(FormattableString filter)
    {
      var tableClient = GetTableClient();
      Pageable<T> result = tableClient.Query<T>(TableClient.CreateQueryFilter(filter));
      return result;
    }
  }
}
