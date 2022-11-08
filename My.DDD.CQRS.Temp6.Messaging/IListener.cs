namespace My.DDD.CQRS.Temp6.Messaging.Hosting;

public interface IListener
{
    event EventHandler<MessageEventArgs> Received;

    void Listen();

    void StopListen();
}