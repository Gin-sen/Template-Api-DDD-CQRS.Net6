using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Users
{
    public class GetByIdUserQuery : IQuery<UserResult?>
    {
        public int UserId { get; set; }
    }
}
