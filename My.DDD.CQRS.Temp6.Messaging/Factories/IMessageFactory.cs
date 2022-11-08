namespace My.DDD.CQRS.Temp6.Messaging.Factories;

public interface IMessageFactory
{
    Message Build(object value);
}