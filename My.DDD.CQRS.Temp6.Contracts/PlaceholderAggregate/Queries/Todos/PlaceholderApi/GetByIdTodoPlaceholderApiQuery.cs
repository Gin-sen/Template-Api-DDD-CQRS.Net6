using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos.PlaceholderApi
{
    public class GetByIdTodoPlaceholderApiQuery : IQuery<TodoResult?>
    {
        public int TodoId { get; set; }
    }
}
