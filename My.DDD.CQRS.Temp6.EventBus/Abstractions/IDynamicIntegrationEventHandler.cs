using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.EventBus.Abstractions
{
  public interface IDynamicIntegrationEventHandler
  {
    Task Handle(dynamic eventData);
  }
}
