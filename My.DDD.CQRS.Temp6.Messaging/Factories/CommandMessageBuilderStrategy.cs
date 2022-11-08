using My.DDD.CQRS.Temp6.CQRS.Commands;
using Newtonsoft.Json;

namespace My.DDD.CQRS.Temp6.Messaging.Factories;

public class CommandMessageBuilderStrategy : IMessageBuilderStrategy
{
    public bool CanBuild(object value)
    {
        var result = value is ICommandBaseRequest;

        return result;
    }

    public Message Build(object value)
    {
        var messagingCommand = (ICommandBaseRequest)value;

        var messageBody = JsonConvert.SerializeObject(messagingCommand);
        Message? result = new(messageBody);

        var headerName = HeaderNamer.GetEventClassName(value.GetType());
        result.Headers.Add(MessagingConstants.ClassName, headerName);

        return result;
    }
}