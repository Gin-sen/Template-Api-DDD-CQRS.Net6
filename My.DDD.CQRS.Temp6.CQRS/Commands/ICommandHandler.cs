using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS.Commands
{

  public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommandRequest<TResult>
  { }

  public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommandRequest
  { }


}
