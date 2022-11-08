namespace My.DDD.CQRS.Temp6.Messaging.Contexting;

public interface IMessageContextAccessor
{
  IMessageContext? Current { get; }
}