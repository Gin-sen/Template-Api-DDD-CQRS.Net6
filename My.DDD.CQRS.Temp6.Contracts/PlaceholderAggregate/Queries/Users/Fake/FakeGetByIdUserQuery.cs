using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users.Fake
{
    public class FakeGetByIdUserQuery : IQuery<UserResult?>
    {

        public int UserId { get; set; }
    }
}
