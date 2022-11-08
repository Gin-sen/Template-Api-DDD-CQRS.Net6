namespace My.DDD.CQRS.Temp6.Messaging.Contexting;

public class MessageContext : IMessageContext
{
    public MessageContext(Message message)
    {
        Message = message;
    }

    public Message Message { get; }
}