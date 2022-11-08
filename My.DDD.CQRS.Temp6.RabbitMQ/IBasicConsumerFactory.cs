using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace My.DDD.CQRS.Temp6.RabbitMQ;

public interface IBasicConsumerFactory
{
    EventingBasicConsumer Build(IModel model);
}