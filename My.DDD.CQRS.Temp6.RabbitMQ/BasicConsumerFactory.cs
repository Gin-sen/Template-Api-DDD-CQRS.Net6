using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace My.DDD.CQRS.Temp6.RabbitMQ;

public class BasicConsumerFactory : IBasicConsumerFactory
{
  public EventingBasicConsumer Build(IModel model)
  {
    EventingBasicConsumer? result = new(model);

    return result;
  }
}