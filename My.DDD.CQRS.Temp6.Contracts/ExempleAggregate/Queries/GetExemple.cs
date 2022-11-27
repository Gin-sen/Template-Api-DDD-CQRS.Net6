using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries
{
  internal class GetExemple : IRequest<IList<ExempleResult>>
  {
    public string ExempleString { get; }
  }
}
