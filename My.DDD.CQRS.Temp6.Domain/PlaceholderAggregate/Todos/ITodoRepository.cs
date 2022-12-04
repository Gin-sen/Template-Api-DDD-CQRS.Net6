using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos
{
  public interface ITodoRepository : IReadRepository<Todo>
  {

    TodoAggregate GetTodoAggregate();
  }
}
