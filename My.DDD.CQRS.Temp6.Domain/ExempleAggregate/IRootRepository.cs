using My.DDD.CQRS.Temp6.CQRS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Domain.ExempleAggregate
{
  public interface IRootRepository : IAggregateAzTablesRepository<Root>
  {
    Task<Root?> Get(); 
  }
}
