using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries
{
  internal class GetExemple : IRequest<IList<ListExempleResult>>
  {
    public string ExempleString1 { get; }
    public string ExempleString2 { get; }

    public GetExemple(string exempleString1, string exempleString2)
    {
      ExempleString1 = exempleString1;
      ExempleString2 = exempleString2;
    }
  }
}
