using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos.Fake
{
  public class FakeGetByIdTodoQuery : IQuery<TodoResult?>
  {

    public int TodoId { get; set; }
  }
}
