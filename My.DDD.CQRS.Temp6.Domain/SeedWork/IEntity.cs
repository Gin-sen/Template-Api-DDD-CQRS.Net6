namespace My.DDD.CQRS.Temp6.Domain.SeedWork
{
  public interface IEntity : IEntity<int>
  {
  }

  public interface IEntity<TId> : IEntityBase
  {
    TId? Id { get; }
  }
}
