using Hubbix.Common.Messaging.Delegating;
using Hubbix.Common.Messaging.Factories;
using My.DDD.CQRS.Temp6.CQRS.Commands;
using My.DDD.CQRS.Temp6.RabbitMQ.Modeling;
using RabbitMQ.Client;
using System.Text;

namespace My.DDD.CQRS.Temp6.RabbitMQ;

public class MessagingSender : IMessagingSender
{
    private readonly IModelProvider modelProvider;
    private readonly IMessageHandler messageHandler;
    private readonly IMessagingTransaction messagingTransaction;
    private readonly IMessageFactory messageFactory;

    public MessagingSender(
      IModelProvider modelProvider,
      IMessageHandler messageHandler,
      IMessagingTransaction messagingTransaction,
      IMessageFactory messageFactory)
    {
        this.modelProvider = modelProvider;
        this.messageHandler = messageHandler;
        this.messagingTransaction = messagingTransaction;
        this.messageFactory = messageFactory;
    }

    public void Send<TCommandBaseRequest>(TCommandBaseRequest command)
      where TCommandBaseRequest : ICommandBaseRequest
    {
        var message = messageFactory.Build(command);

        messageHandler.Process(message);

        Send(command, message);
    }

    private void Send(ICommandBaseRequest command, Message message)
    {
        var queueName = QueueNamer.GetQueueName(command.GetType().Assembly);
        var properties = BuildProperties(message);
        var body = BuildBody(message);

        messagingTransaction?.Begin();

        modelProvider.Current.BasicPublish(string.Empty, queueName, true, properties, body);
    }

    private IBasicProperties BuildProperties(Message message)
    {
        var result = modelProvider.Current.CreateBasicProperties();

        result.Persistent = true;
        result.Headers = message.Headers.ToDictionary(x => x.Key, x => (object)x.Value.ToString());

        return result;
    }

    private static byte[]? BuildBody(Message message)
    {
        return message.Body != null ? Encoding.UTF8.GetBytes(message.Body) : null;
    }
}