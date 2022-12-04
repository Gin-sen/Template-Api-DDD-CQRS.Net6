using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Users;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Events.Users;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using MY.DDD.CQRS.Temp6.CQRS.Commands;
using MY.DDD.CQRS.Temp6.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Commands.Users
{
  public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, int>
  {
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreateUserCommandHandler> _logger;
    private readonly IMediator _mediator;


    public CreateUserCommandHandler(IUserRepository userRepository, IMediator mediator, ILogger<CreateUserCommandHandler> logger)
    {
      _userRepository = userRepository;
      _mediator = mediator;
      _logger = logger;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      User user = request.Adapt<User>();
      int id = await _userRepository.AddUser(user);
      IEvent @event = new UserCreatedEvent() { User = user };
      await _mediator.Publish(@event);
      return id;
    }
  }
}
