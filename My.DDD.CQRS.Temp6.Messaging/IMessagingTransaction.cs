namespace My.DDD.CQRS.Temp6.Messaging;
public interface IMessagingTransaction
{
    void Begin();

    void Complete();

    void Rollback();
}
