using MediatR;

namespace MY.DDD.CQRS.Temp6.CQRS.Commands
{
  public interface ICommand<out TResult> : IRequest<TResult>
  {
  }
  public interface ICommand : IRequest
  {
  }
}
