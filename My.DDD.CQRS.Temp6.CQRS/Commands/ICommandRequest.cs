using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS.Commands
{

  public interface ICommandRequest<out TResult> : IRequest<TResult>, ICommandBaseRequest { }

  public interface ICommandRequest : IRequest<Unit>, ICommandRequest<Unit> { }

}
