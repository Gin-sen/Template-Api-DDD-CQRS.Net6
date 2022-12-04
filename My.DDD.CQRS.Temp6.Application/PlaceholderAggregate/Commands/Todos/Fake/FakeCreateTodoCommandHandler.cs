using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos.Fake;
using My.DDD.CQRS.Temp6.DBAccess;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using MY.DDD.CQRS.Temp6.CQRS.Commands;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Commands.Todos.Fake
{
  public class FakeCreateTodoCommandHandler : ICommandHandler<FakeCreateTodoCommand, bool>
  {
    private readonly FakeBdContext _fakeDbContext;

    public FakeCreateTodoCommandHandler(FakeBdContext fakeDbContext)
    {
      _fakeDbContext = fakeDbContext;
    }

    public async Task<bool> Handle(FakeCreateTodoCommand request, CancellationToken cancellationToken)
    {
      try
      {
        await _fakeDbContext.AddTodo(new Todo() { Id = request.Id, UserId = request.UserId, Completed = request.Completed, Title = request.Title });
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
