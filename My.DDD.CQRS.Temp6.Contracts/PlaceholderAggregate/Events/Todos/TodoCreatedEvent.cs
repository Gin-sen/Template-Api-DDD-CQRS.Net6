using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using MY.DDD.CQRS.Temp6.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Events.Todos
{
  public class TodoCreatedEvent : IEvent
  {
    public Todo Todo { get; set; }
  }
}
