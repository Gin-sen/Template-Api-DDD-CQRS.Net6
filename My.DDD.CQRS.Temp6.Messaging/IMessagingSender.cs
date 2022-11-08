using My.DDD.CQRS.Temp6.CQRS.Commands;

namespace My.DDD.CQRS.Temp6.Messaging;

public interface IMessagingSender
{
    void Send<TCommandBaseRequest>(TCommandBaseRequest command)
      where TCommandBaseRequest : ICommandBaseRequest;
}