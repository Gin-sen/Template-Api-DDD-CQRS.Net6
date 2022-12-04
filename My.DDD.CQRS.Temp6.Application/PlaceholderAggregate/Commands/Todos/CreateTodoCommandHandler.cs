using Mapster;
using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Events.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using MY.DDD.CQRS.Temp6.CQRS.Commands;
using MY.DDD.CQRS.Temp6.CQRS.Events;
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
    private readonly IMediator _mediator;

    public CreateTodoCommandHandler(ITodoRepository todoRepository, IMediator mediator)
    {
      _todoRepository = todoRepository;
      _mediator = mediator;
    }

    public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
      Todo todo = request.Adapt<Todo>();
      int id = await _todoRepository.AddTodo(todo);
      IEvent @event = new TodoCreatedEvent() { Todo = todo };
      await _mediator.Publish(@event);
      return id;
    }
  }
}
