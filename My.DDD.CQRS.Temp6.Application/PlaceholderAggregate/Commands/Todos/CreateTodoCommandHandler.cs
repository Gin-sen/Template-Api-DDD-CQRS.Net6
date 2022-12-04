using Mapster;
using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using MY.DDD.CQRS.Temp6.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Commands.Todos
{
  public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, int>
  {

    private readonly ITodoRepository _todoRepository;

    public CreateTodoCommandHandler(ITodoRepository todoRepository)
    {
      _todoRepository = todoRepository;
    }

    public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
      Todo todo = request.Adapt<Todo>();
      int id = await _todoRepository.AddTodo(todo);
      return id;
    }
  }
}
