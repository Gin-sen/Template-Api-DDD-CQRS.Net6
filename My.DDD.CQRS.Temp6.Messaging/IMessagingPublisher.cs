using My.DDD.CQRS.Temp6.CQRS.Events;

namespace My.DDD.CQRS.Temp6.Messaging;

public interface IMessagingPublisher
{
  void Publish<TIntegrationEvent>(TIntegrationEvent integrationEvent)
    where TIntegrationEvent : IIntegrationEvent;
}