using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos.Fake
{
  public class FakeCreateTodoCommand : IRequest<bool>
  {
    public int UserId { get; set; }

    public int Id { get; set; }

    public string Title { get; set; }

    public bool Completed { get; set; }
  }
}
