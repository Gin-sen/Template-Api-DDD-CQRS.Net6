using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos.Fake;
using My.DDD.CQRS.Temp6.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Todos.Fake
{
    public class FakeGetByIdTodoQuery : IRequestHandler<FakeGetByIdTodo, TodoResult?>
    {
        private readonly FakeBdContext _fakeDbContext;
        public FakeGetByIdTodoQuery(FakeBdContext fakeDbContext)
        {
            _fakeDbContext = fakeDbContext;
        }

        public async Task<TodoResult?> Handle(FakeGetByIdTodo request, CancellationToken cancellationToken)
        {
            var res = await _fakeDbContext.GetTodo(request.TodoId);
            if (res == null)
                return null;
            return new TodoResult() { Id = res.Id, UserId = res.UserId, Completed = res.Completed, Title = res.Title };
        }
    }
}
