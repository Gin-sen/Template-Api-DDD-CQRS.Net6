using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands
{
  public class CreateOrIncrementExemple : IRequest<CreateOrIncrementResult>
  {
    public string StringExemple { get; set; }

  }
}
