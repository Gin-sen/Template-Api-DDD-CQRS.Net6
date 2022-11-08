namespace My.DDD.CQRS.Temp6.Messaging.Delegating;

public interface IMessageHandler
{
    void Process(Message message);
}