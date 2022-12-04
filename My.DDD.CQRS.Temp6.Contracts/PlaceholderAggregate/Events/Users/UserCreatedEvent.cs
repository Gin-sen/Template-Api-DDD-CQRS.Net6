using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using MY.DDD.CQRS.Temp6.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Events.Users
{
    public class UserCreatedEvent : IEvent
    {
    public User User { get; set; }
  }
}
