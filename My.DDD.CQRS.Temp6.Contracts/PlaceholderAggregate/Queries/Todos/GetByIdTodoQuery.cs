using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using MY.DDD.CQRS.Temp6.CQRS.Queries;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos
{
  public class GetByIdTodoQuery : IQuery<TodoResult?>
  {
    public int TodoId { get; set; }
  }
}
