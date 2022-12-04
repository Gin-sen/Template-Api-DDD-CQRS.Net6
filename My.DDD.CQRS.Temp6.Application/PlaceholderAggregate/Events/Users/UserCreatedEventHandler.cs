using Microsoft.Extensions.Logging;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Events.Users;
using MY.DDD.CQRS.Temp6.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Events.Users
{
  public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
  {
    private readonly ILogger<UserCreatedEventHandler> _logger;

    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
    {
      _logger = logger;
    }

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {

      _logger.LogInformation("Handling UserCreatedEvent for {TodoId}", notification.User.Id);
      await Task.Delay(5000);
      _logger.LogInformation("UserCreatedEvent for {TodoId} - Done", notification.User.Id);
    }
  }
}
