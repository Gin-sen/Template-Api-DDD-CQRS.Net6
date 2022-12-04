using Mapster;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.Fake;
using My.DDD.CQRS.Temp6.DBAccess;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Users.Fake
{
    public class FakeGetByIdUserQueryHandler : IQueryHandler<FakeGetByIdUserQuery, UserResult?>
    {
        private readonly FakeBdContext _fakeDbContext;
        public FakeGetByIdUserQueryHandler(FakeBdContext fakeDbContext)
        {
            _fakeDbContext = fakeDbContext;
        }

        public async Task<UserResult?> Handle(FakeGetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _fakeDbContext.GetUser(request.UserId);
            if (result == null)
                return null;
            return result.Adapt<UserResult>();
        }
    }
}
