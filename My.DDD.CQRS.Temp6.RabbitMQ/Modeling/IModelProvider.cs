using RabbitMQ.Client;

namespace My.DDD.CQRS.Temp6.RabbitMQ.Modeling;

public interface IModelProvider
{
    IModel Current { get; }
}
