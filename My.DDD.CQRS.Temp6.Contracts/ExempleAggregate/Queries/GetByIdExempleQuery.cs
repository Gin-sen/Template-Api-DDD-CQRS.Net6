using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries
{
  public class GetByIdExempleQuery : IQuery<ExempleResult?>
  {
    public string ExempleString { get; set; }
  }
}
