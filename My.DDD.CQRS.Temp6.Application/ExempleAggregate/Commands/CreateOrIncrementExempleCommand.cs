using MediatR;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.ExempleAggregate.Commands
{
  public class CreateOrIncrementExempleCommand :
    IRequestHandler<CreateOrIncrementExemple, CreateOrIncrementResult>
  {
    private readonly IExempleRepository _exempleRepository;

    public CreateOrIncrementExempleCommand(IExempleRepository exempleRepository)
    {
      _exempleRepository = exempleRepository;
    }

    public async Task<CreateOrIncrementResult> Handle(CreateOrIncrementExemple request,
      CancellationToken cancellationToken)
    {
      await _exempleRepository.AddAsync(request.StringExemple, cancellationToken);
      var result = await _exempleRepository.GetAsync(request.StringExemple, cancellationToken);
      return new CreateOrIncrementResult() { StringExemple = result.PartitionKey, Increment = result.Increment };
    }
  }
}
