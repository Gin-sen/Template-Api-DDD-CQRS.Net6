using Mapster;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos.Fake;
using My.DDD.CQRS.Temp6.DBAccess;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Todos.Fake
{
  public class FakeGetByIdTodoQueryHandler : IQueryHandler<FakeGetByIdTodoQuery, TodoResult?>
  {
    private readonly FakeBdContext _fakeDbContext;
    public FakeGetByIdTodoQueryHandler(FakeBdContext fakeDbContext)
    {
      _fakeDbContext = fakeDbContext;
    }

    public async Task<TodoResult?> Handle(FakeGetByIdTodoQuery request, CancellationToken cancellationToken)
    {
      var res = await _fakeDbContext.GetTodo(request.TodoId);
      if (res == null)
        return null;
      return res.Adapt<TodoResult>();
    }
  }
}
