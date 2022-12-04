using MediatR;

namespace MY.DDD.CQRS.Temp6.CQRS.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
