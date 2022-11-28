using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.Fake;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.DDD.CQRS.Temp6.DBAccess;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users.Fake
{
  public class FakeGetAllUsersQuery : IRequestHandler<FakeGetAllUsers, IEnumerable<UserResult>>
  {

    private readonly FakeBdContext _fakeDbContext;

    public FakeGetAllUsersQuery(FakeBdContext fakeDbContext)
    {
      _fakeDbContext = fakeDbContext;
    }

    public async Task<IEnumerable<UserResult>> Handle(FakeGetAllUsers request, CancellationToken cancellationToken)
    {
      var result = await _fakeDbContext.GetAllUsers();
      var finalResult = new List<UserResult>();
      for (int i = 0; i < result.Count(); i++)
      {
        var element = result.ElementAt(i);
        finalResult.Add(new UserResult()
        {
          Id = element.Id,
          Name = element.Name,
          Email = element.Email,
          Username = element.Username,
          Phone = element.Phone,
          Website = element.Website
        });
      }
      return finalResult;
    }
  }
}
