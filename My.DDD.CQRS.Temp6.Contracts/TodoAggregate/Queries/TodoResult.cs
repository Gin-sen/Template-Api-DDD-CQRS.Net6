using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.TodoAggregate.Queries
{
  public class TodoResult
  {
    public int UserId;

    public int Id;

    public string Title;

    public bool Completed;
  }
}
