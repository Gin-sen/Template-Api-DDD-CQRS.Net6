using RabbitMQ.Client.Events;

namespace My.DDD.CQRS.Temp6.RabbitMQ.Replay;
public interface IReplayStrategy
{
  void Replay(BasicDeliverEventArgs basicDeliverEventArgs, Exception ex);
}
