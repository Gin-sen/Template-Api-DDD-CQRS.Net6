using My.DDD.CQRS.Temp6.CQRS.Commands;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.ExempleAggregate.Commands
{
  public class CreateOrIncrementExempleCommand : 
    ICommandHandler<CreateOrIncrementExemple, CreateOrIncrementResult>
  {
    public Task<CreateOrIncrementResult> Handle(CreateOrIncrementExemple request,
      CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
