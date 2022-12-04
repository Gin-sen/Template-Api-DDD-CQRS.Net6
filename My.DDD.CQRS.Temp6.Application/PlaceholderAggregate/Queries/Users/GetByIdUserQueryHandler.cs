using Mapster;
using Microsoft.EntityFrameworkCore;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using My.DDD.CQRS.Temp6.Domain.SeedWork;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users
{
  public class GetByIdUserQueryHandler : IQueryHandler<GetByIdUserQuery, UserResult?>
  {
    private readonly IUserRepository _userRepository;
    //private readonly IReadRepository<User> _userRepository;

    public GetByIdUserQueryHandler(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<UserResult?> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
      var result = await _userRepository.GetAll().FirstOrDefaultAsync(user => user.Id == request.UserId, cancellationToken);

      if (Entity.Equals(result, null))
        return null;

      UserResult userResult = result.Adapt<UserResult>();
      return userResult;
    }
  }
}
