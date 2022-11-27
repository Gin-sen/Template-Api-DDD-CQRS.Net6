using MediatR;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.ExempleAggregate.Queries
{
  public class GetByIdExempleQuery : IRequestHandler<GetByIdExemple, ExempleResult?>
  {
    private readonly IExempleRepository _exempleRepository;

    public GetByIdExempleQuery(IExempleRepository exempleRepository)
    {
      _exempleRepository = exempleRepository;
    }

    public async Task<ExempleResult?> Handle(GetByIdExemple request, CancellationToken cancellationToken)
    {
      var result = await _exempleRepository.GetAsync(request.ExempleString, cancellationToken);
      if (result== null)
        return null;
      return new ExempleResult()
      {
        PartitionKey = result.PartitionKey,
        RowKey = result.RowKey,
        Increment = result.Increment,
        TimeStamp = result.Timestamp
      };
    }
  }
}
