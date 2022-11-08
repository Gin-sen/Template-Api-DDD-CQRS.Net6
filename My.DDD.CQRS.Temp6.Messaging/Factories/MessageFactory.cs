using My.DDD.CQRS.Temp6.Errors;
using My.DDD.CQRS.Temp6.Messaging.Properties;

namespace My.DDD.CQRS.Temp6.Messaging.Factories;

public class MessageFactory : IMessageFactory
{
    private readonly IEnumerable<IMessageBuilderStrategy> messageBuilderStrategies;

    public MessageFactory(IEnumerable<IMessageBuilderStrategy> messageBuilderStrategies)
    {
        this.messageBuilderStrategies = messageBuilderStrategies;
    }

    public Message Build(object value)
    {
        IMessageBuilderStrategy? messageBuilderStrategy = messageBuilderStrategies.SingleOrDefault(messageBuilderStrategy => messageBuilderStrategy.CanBuild(value));

        if (messageBuilderStrategy == null)
        {
            throw new TechnicalException(string.Format(Resources.MessagingBuilderStrategyNotFoundException, value.GetType()));
        }

        var result = messageBuilderStrategy.Build(value);

        return result;
    }
}