namespace My.DDD.CQRS.Temp6.Domain.ExempleAggregate
{
  public interface IExempleService
  {

    Task<Exemple> GetAsync(string exemple, CancellationToken cancellationToken);

    Task<IEnumerable<Exemple>> GetAllAsync(CancellationToken cancellationToken);

    Task AddAsync(string exemple, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<Exemple> entities, CancellationToken cancellationToken);

    void Remove(Exemple entity);

    void RemoveRange(IEnumerable<Exemple> entities);
  }
}
