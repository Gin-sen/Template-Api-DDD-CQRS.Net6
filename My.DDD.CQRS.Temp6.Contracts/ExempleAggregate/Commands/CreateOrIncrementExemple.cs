using My.DDD.CQRS.Temp6.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands
{
  public class CreateOrIncrementExemple : ICommandRequest<CreateOrIncrementResult>
  {
    public string StringExemple { get; }

    public CreateOrIncrementExemple(string strinExemple)
    {
      StringExemple = strinExemple;
    }
  }
}
