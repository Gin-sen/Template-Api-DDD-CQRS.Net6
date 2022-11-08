using My.DDD.CQRS.Temp6.CQRS.Events;
using Newtonsoft.Json;

namespace My.DDD.CQRS.Temp6.Messaging.Factories;

public class IntegrationEventMessageBuilderStrategy : IMessageBuilderStrategy
{
    public bool CanBuild(object value)
    {
        var result = value is IIntegrationEvent;

        return result;
    }

    public Message Build(object value)
    {
        var messagingEvent = (IIntegrationEvent)value;

        var messageBody = JsonConvert.SerializeObject(messagingEvent);
        Message? result = new(messageBody);

        var headerName = HeaderNamer.GetEventClassName(value.GetType());
        result.Headers.Add(MessagingConstants.ClassName, headerName);

        return result;
    }
}