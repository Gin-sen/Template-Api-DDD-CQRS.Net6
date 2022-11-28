using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos.Fake;
using My.DDD.CQRS.Temp6.DBAccess;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Commands.Todos.Fake
{
  public class FakeCreateTodoCommand : IRequestHandler<FakeCreateTodo, bool>
  {
    private readonly FakeBdContext _fakeDbContext;

    public FakeCreateTodoCommand(FakeBdContext fakeDbContext)
    {
      _fakeDbContext = fakeDbContext;
    }

    public async Task<bool> Handle(FakeCreateTodo request, CancellationToken cancellationToken)
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
