using Mapster;
using Microsoft.EntityFrameworkCore;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using My.DDD.CQRS.Temp6.Domain.SeedWork;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Todos
{
  public class GetByIdTodoQueryHandler : IQueryHandler<GetByIdTodoQuery, TodoResult?>
  {
    private readonly ITodoRepository _todoRepository;
    //private readonly IReadRepository<Todo> _todoRepository;

    public GetByIdTodoQueryHandler(ITodoRepository todoRepository)
    {
      _todoRepository = todoRepository;
    }

    public async Task<TodoResult?> Handle(GetByIdTodoQuery request, CancellationToken cancellationToken)
    {

      var result = await _todoRepository.GetAll().FirstOrDefaultAsync(todo => todo.Id == request.TodoId, cancellationToken);

      if (Entity.Equals(result, null))
        return null;

      TodoResult userResult = result.Adapt<TodoResult>();
      return userResult;
    }
  }
}
