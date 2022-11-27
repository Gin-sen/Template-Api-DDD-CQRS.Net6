using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Domain.TodoAggregate
{
  public interface IPlaceholderClient
  {
    Task<Todo?> GetTodo(int id);
  }
}
