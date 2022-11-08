using RabbitMQ.Client;

namespace My.DDD.CQRS.Temp6.RabbitMQ.Connections;

public interface IConnectionProvider
{
    IConnection Current { get; }
}
