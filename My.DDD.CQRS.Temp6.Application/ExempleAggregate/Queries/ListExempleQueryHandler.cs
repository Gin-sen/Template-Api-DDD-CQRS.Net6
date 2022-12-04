using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.ExempleAggregate.Queries
{
  public class ListExempleQueryHandler : IQueryHandler<ListExempleQuery, IList<ExempleResult>>
  {
    private readonly IExempleService _exempleRepository;

    public ListExempleQueryHandler(IExempleService exempleRepository)
    {
      _exempleRepository = exempleRepository;
    }

    public async Task<IList<ExempleResult>> Handle(ListExempleQuery request, CancellationToken cancellationToken)
    {
      var result = await _exempleRepository.GetAllAsync(cancellationToken);
      var finalResult = new List<ExempleResult>();
      for (int i = 0; i < result.Count(); i++)
      {
        var element = result.ElementAt(i);
        finalResult.Add(new ExempleResult()
        {
          PartitionKey = element.PartitionKey,
          RowKey = element.RowKey,
          Increment = element.Increment,
          TimeStamp = element.Timestamp
        });
      }
      return finalResult;
    }
  }
}
