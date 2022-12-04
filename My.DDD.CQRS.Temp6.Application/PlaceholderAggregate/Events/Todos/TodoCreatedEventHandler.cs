using Microsoft.Extensions.Logging;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Events.Todos;
using MY.DDD.CQRS.Temp6.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Events.Todos
{
  public class TodoCreatedEventHandler : IEventHandler<TodoCreatedEvent>
  {
    private readonly ILogger<TodoCreatedEventHandler> _logger;

    public TodoCreatedEventHandler(ILogger<TodoCreatedEventHandler> logger)
    {
      _logger = logger;
    }

    public async Task Handle(TodoCreatedEvent notification, CancellationToken cancellationToken)
    {
      _logger.LogInformation("Handling TodoCreatedEvent for {TodoId}", notification.Todo.Id);
      await Task.Delay(5000);
      _logger.LogInformation("TodoCreatedEvent for {TodoId} - Done", notification.Todo.Id);

    }
  }
}
