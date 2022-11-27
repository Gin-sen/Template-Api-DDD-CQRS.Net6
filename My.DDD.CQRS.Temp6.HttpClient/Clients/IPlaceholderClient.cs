using My.DDD.CQRS.Temp6.HttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.HttpClients.Clients
{
  public interface IPlaceholderClient
  {
    Task<Todo?> GetTodo(int id);
  }
}
