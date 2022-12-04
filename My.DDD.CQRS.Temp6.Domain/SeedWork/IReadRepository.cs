namespace My.DDD.CQRS.Temp6.Domain.SeedWork
{
  public interface IReadRepository<TEntity>
                  where TEntity : IEntityBase
  {
    IQueryable<TEntity> GetAll();
  }

}
