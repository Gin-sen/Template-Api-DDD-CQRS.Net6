using Mapster;
using Microsoft.EntityFrameworkCore;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using My.DDD.CQRS.Temp6.Domain.SeedWork;
using MY.DDD.CQRS.Temp6.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Todos
{
  public class GetAllTodosQueryHandler : IQueryHandler<GetAllTodosQuery, IEnumerable<TodoResult>>
  {
    private readonly ITodoRepository _todoRepository;

    public GetAllTodosQueryHandler(ITodoRepository todoRepository)
    {
      _todoRepository = todoRepository;
    }

    public Task<IEnumerable<TodoResult>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {

      var result = _todoRepository.GetAll();

      IEnumerable<TodoResult> todosResult = result.Adapt<IEnumerable<TodoResult>>();
      return Task.FromResult(todosResult);
    }
  }
}
