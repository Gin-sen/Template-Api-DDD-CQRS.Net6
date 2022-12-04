using MediatR;

namespace MY.DDD.CQRS.Temp6.CQRS.Events
{
  public interface IEventHandler<TEvent> : INotificationHandler<TEvent>
  where TEvent : IEvent
  { }
}
