namespace My.DDD.CQRS.Temp6.Messaging.Hosting;

public class MessageEventArgs : EventArgs
{
    public MessageEventArgs(Message message)
    {
        Message = message;
    }

    public Message Message { get; private set; }
}