using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos
{
  public class TodoAggregate : IAggregateRoot
  {

    private readonly IQueryable<Todo> todos;

    public TodoAggregate(IQueryable<Todo> todos)
    {
      this.todos = todos;
    }
  }
}
