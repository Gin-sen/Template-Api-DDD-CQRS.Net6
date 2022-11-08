using RabbitMQ.Client;

namespace My.DDD.CQRS.Temp6.RabbitMQ.Connections;

public interface IConnectionFactoryProvider
{
    IConnectionFactory Current { get; }
}
