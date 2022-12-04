using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MY.DDD.CQRS.Temp6.CQRS.Commands;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands
{
  public class CreateOrIncrementExempleCommand : ICommand<CreateOrIncrementResult>
  {
    public string StringExemple { get; set; }

  }
}
