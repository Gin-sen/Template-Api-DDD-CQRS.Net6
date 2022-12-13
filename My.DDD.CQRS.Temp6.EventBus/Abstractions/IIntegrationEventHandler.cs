using My.DDD.CQRS.Temp6.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.EventBus.Abstractions
{
  public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
      where TIntegrationEvent : IntegrationEvent
  {
    Task Handle(TIntegrationEvent @event);
  }

  public interface IIntegrationEventHandler
  {
  }
}
