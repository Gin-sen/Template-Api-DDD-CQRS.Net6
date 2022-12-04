using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users
{
  public class UserAggregate : IAggregateRoot
  {
    private readonly IQueryable<User> users;

    public UserAggregate(IQueryable<User> users)
    {
      this.users = users;
    }
  }
}
