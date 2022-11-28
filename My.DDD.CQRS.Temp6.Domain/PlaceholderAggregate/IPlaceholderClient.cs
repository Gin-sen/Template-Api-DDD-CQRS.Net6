
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate
{
    public interface IPlaceholderClient
  {
    Task<Todo?> GetTodo(int id);
    Task<User?> GetUser(int id);
  }
}
