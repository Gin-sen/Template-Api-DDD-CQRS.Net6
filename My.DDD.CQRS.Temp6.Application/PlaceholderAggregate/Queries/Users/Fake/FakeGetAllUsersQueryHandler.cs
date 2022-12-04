using Mapster;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.Fake;
using My.DDD.CQRS.Temp6.DBAccess;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users.Fake
{
  public class FakeGetAllUsersQueryHandler : IQueryHandler<FakeGetAllUsersQuery, IEnumerable<UserResult>>
  {

    private readonly FakeBdContext _fakeDbContext;

    public FakeGetAllUsersQueryHandler(FakeBdContext fakeDbContext)
    {
      _fakeDbContext = fakeDbContext;
    }

    public async Task<IEnumerable<UserResult>> Handle(FakeGetAllUsersQuery request, CancellationToken cancellationToken)
    {
      var result = await _fakeDbContext.GetAllUsers();
      var finalResult = new List<UserResult>();
      for (int i = 0; i < result.Count(); i++)
      {
        var element = result.ElementAt(i);
        finalResult.Add(element.Adapt<UserResult>());
      }
      return finalResult;
    }
  }
}
