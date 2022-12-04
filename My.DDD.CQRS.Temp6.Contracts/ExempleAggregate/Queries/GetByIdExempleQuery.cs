using MediatR;
using MY.DDD.CQRS.Temp6.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries
{
  public class GetByIdExempleQuery : IQuery<ExempleResult?>
  {
    public string ExempleString { get; set; }
  }
}
