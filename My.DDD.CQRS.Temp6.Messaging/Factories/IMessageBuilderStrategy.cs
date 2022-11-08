
namespace My.DDD.CQRS.Temp6.Messaging.Factories;

/// <summary>
/// TODO: Scoped
/// </summary>
public interface IMessageBuilderStrategy
{
  bool CanBuild(object value);

  Message Build(object value);
}