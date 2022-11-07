using My.DDD.CQRS.Temp6.AzureTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.AzureTables.Tables
{
  public interface IExempleTable
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="exempleString1"></param>
    /// <param name="exempleString2"></param>
    /// <returns></returns>
    Task<ExempleEntity> GetExempleAsync(string exempleString1, string exempleString2);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ExempleEntity>> GetAllAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="exempleString1"></param>
    /// <param name="exempleString2"></param>
    /// <returns></returns>
    Task AddOrUpdateExempleAsync(string exempleString1, string exempleString2);

  }
}
