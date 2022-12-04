using Mapster;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using MY.DDD.CQRS.Temp6.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users
{
  public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<UserResult>>
  {
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public Task<IEnumerable<UserResult>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
      var result = _userRepository.GetAll();
      IEnumerable<UserResult> userResults = result.Adapt<IEnumerable<UserResult>>();
      return Task.FromResult(userResults);
    }
  }
}
