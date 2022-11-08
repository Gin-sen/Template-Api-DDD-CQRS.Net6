namespace My.DDD.CQRS.Temp6.Messaging;

/// <summary>
/// TODO: Scoped
/// </summary>
public interface IMessageBuilder
{
  public bool CanBuild(Message message);

  public void Build(Message message);
}