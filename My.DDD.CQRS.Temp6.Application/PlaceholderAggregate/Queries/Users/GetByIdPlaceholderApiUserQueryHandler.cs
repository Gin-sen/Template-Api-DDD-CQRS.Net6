using Mapster;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users
{
  public class GetByIdPlaceholderApiUserQueryHandler : IQueryHandler<GetByIdUserPlaceholderApiQuery, UserResult?>
  {
    private readonly IPlaceholderClient _placeholderClient;

    public GetByIdPlaceholderApiUserQueryHandler(IPlaceholderClient placeholderClient)
    {
      _placeholderClient = placeholderClient;
    }

    public async Task<UserResult?> Handle(GetByIdUserPlaceholderApiQuery request, CancellationToken cancellationToken)
    {
      var result = await _placeholderClient.GetUser(request.UserId);
      if (result == null)
        return null;
      return result.Adapt<UserResult>();
    }
  }
}
