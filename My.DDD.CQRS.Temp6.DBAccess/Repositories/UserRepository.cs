using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.DBAccess.Repositories
{
  public class UserRepository : AggregateRepository<User>, IUserRepository
  {
    private readonly ApplicationDbContext applicationDbContext;
    public UserRepository(ApplicationDbContext applicationDbContext, IUnitOfWork<User> unitOfWork) : base(unitOfWork)
    {
      this.applicationDbContext = applicationDbContext;
    }

    public IQueryable<User> GetAll()
    {
      return applicationDbContext.Users.AsQueryable();
    }

    public UserAggregate GetUserAggregate()
    {
      var resultat = new UserAggregate(applicationDbContext.Users);

      return resultat;
    }

    public async Task<int> AddUser(User user)
    {
      await this.AddAsync(user);
      await this.SaveChangesAsync();
      return user.Id;
    }
  }
}
