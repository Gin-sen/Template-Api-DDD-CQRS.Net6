using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Commands
{

  public class CreateOrIncrementResult
  {
    public string StringExemple { get; set; }
    public int Increment { get; set; }
  }
}
