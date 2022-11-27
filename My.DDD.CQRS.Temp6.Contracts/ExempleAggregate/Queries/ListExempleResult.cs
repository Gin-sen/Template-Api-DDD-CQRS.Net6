using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries
{
  public class ListExempleResult
  {
    public int Increment { get; private set; }
    public string ExempleString1 { get; private set; }
    public string ExempleString2 { get; private set; }
  }
}
