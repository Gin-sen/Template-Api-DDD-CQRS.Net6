using Hubbix.Common.Business.Events;
using Hubbix.Common.Messaging.Delegating;
using Hubbix.Common.Messaging.Factories;
using Hubbix.Common.Messaging.RabbitMQ.Modeling;
using System.Text;

namespace My.DDD.CQRS.Temp6.RabbitMQ;

public class MessagingPublisher : IMessagingPublisher
{
  private readonly IModelProvider modelProvider;
  private readonly IMessagingInitializer messagingInitializer;
  private readonly IMessageFactory messageFactory;
  private readonly IMessageHandler messageHandler;
  private readonly IMessagingTransaction? messagingTransaction;

  public MessagingPublisher(
    IModelProvider modelProvider,
    IMessagingInitializer messagingInitializer,
    IMessageFactory messageFactory,
    IMessageHandler messageHandler,
    IMessagingTransaction? messagingTransaction = null)
  {
    this.modelProvider = modelProvider;
    this.messagingInitializer = messagingInitializer;
    this.messageFactory = messageFactory;
    this.messageHandler = messageHandler;
    this.messagingTransaction = messagingTransaction;
  }

  public void Publish<TIntegrationEvent>(TIntegrationEvent integrationEvent)
    where TIntegrationEvent : IIntegrationEvent
  {
    messagingInitializer.Initialize();

    var message = messageFactory.Build(integrationEvent);

    messageHandler.Process(message);

    var integrationEventAssembly = integrationEvent.GetType().Assembly;
    var exchangeName = ExchangeNamer.GetEventExchangeName(integrationEventAssembly);

    Publish(message, exchangeName);
  }

  private void Publish(Message message, string exchangeName)
  {
    var properties = modelProvider.Current.CreateBasicProperties();
    properties.Persistent = true;
    properties.Headers = message.Headers.ToDictionary(x => x.Key, x => (object)x.Value.ToString());

    var body = message.Body != null ? Encoding.UTF8.GetBytes(message.Body) : null;

    messagingTransaction?.Begin();

    modelProvider.Current.BasicPublish(exchangeName, string.Empty, false, properties, body);
  }
}