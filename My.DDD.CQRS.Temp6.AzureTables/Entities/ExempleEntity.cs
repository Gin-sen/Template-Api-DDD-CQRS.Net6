using Azure.Data.Tables;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.AzureTables.Entities
{
  /// <summary>
  /// This is an exemple of how Azure Table Entities work
  /// Add as many row as you like by adding fields to this class
  /// </summary>
  public class ExempleEntity : ITableEntity
  {
    /// <summary>
    /// Les partitions sont le premier index cherché;
    /// pour des recherches rapides, bien penser 
    /// à quoi mettre dans la PartitionKey
    /// </summary>
    public string PartitionKey { get; set; }

    /// <summary>
    /// Deuxième index cherché en recherche rapide
    /// </summary>
    public string RowKey { get; set; }

    /// <summary>
    /// Incrément 
    /// </summary>
    public int Increment { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset? Timestamp { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ETag ETag { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public ExempleEntity() { }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="exampleString1"></param>
    /// <param name="exampleString1"></param>
    public ExempleEntity(string exampleString1, string exampleString2)
    {
      PartitionKey = exampleString1.ToUpper();
      RowKey = exampleString2.ToLower();
      Increment = 0;
    }
  }
}
