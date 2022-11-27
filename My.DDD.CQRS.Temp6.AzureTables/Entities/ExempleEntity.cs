using Azure.Data.Tables;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;

namespace My.DDD.CQRS.Temp6.AzureTables.Entities
{
  /// <summary>
  /// This is an exemple of how Azure Table Entities work
  /// Add as many row as you like by adding fields to this class
  /// </summary>
  public class ExempleEntity : Exemple, ITableEntity
  {
    public ExempleEntity() : base()
    {
    }

    public ExempleEntity(string exampleString1, string exampleString2) : base(exampleString1, exampleString2)
    {
    }

    public ExempleEntity(string exampleString1, string exampleString2, int increment, DateTimeOffset? timeStamp) : base(exampleString1, exampleString2, increment, timeStamp)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public ETag ETag { get; set; }
  }
}
