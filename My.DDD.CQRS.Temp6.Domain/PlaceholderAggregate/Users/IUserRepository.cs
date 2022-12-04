using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users
{
  public interface IUserRepository : IReadRepository<User>
  {
    Task<int> AddUser(User user);
    UserAggregate GetUserAggregate();
  }
}
