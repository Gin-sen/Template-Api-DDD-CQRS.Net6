using MediatR;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.ExempleAggregate.Queries
{
  public class ListExempleQuery : IRequestHandler<ListExemple, IList<ListExempleResult>>
  {
    public Task<IList<ListExempleResult>> Handle(ListExemple request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
