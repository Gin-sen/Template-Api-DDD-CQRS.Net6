using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Commands.Todos;
using MY.DDD.CQRS.Temp6.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Commands.Todos
{
  public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand>
  {

    public Task<Unit> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
