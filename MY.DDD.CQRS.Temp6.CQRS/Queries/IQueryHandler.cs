using MediatR;

namespace MY.DDD.CQRS.Temp6.CQRS.Queries
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
  where TQuery : IQuery<TResult>
    { }
}
