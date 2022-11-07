using My.DDD.CQRS.Temp6.CQRS.Domain;
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
  public class Exemple : Entity
  {
    /// <summary>
    /// Les partitions sont le premier index cherché;
    /// pour des recherches rapides, bien penser 
    /// à quoi mettre dans la PartitionKey
    /// </summary>
    public string PartitionKey { get; private set; }

    /// <summary>
    /// Deuxième index cherché en recherche rapide
    /// </summary>
    public string RowKey { get; private set; }

    /// <summary>
    /// Incrément 
    /// </summary>
    public int Increment { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset? Timestamp { get; private set; }


    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="exampleString1"></param>
    /// <param name="exampleString1"></param>
    public Exemple(string exampleString1, string exampleString2)
    {
      PartitionKey = exampleString1;
      RowKey = exampleString2;
      Increment = 0;
      Timestamp = DateTime.Now;
    }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="exampleString1"></param>
    /// <param name="exampleString1"></param>
    public Exemple(string exampleString1, string exampleString2, int increment, DateTimeOffset? timeStamp)
    {
      PartitionKey = exampleString1;
      RowKey = exampleString2;
      Increment = increment;
      Timestamp = timeStamp;
    }
  }
}
