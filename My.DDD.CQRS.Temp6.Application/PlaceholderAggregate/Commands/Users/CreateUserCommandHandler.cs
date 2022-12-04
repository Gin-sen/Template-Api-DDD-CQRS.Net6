using Mapster;
using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Users;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using MY.DDD.CQRS.Temp6.CQRS.Commands;
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

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      User user = request.Adapt<User>();
      int id = await _userRepository.AddUser(user);
      return id;
    }
  }
}
