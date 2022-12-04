using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.DBAccess.Repositories
{
    public class UserRepository : AggregateRepository<UserAggregate>, IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext, IUnitOfWork<UserAggregate> unitOfWork) : base(unitOfWork)
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
    }
}
