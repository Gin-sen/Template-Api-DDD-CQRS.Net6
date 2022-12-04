using Mapster;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Todos
{
    public class GetByIdPlaceholderApiTodoQueryHandler : IQueryHandler<GetByIdTodoPlaceholderApiQuery, TodoResult?>
    {
        private readonly IPlaceholderClient _placeholderClient;

        public GetByIdPlaceholderApiTodoQueryHandler(IPlaceholderClient placeholderClient)
        {
            _placeholderClient = placeholderClient;
        }

        public async Task<TodoResult?> Handle(GetByIdTodoPlaceholderApiQuery request, CancellationToken cancellationToken)
        {
            var res = await _placeholderClient.GetTodo(request.TodoId);
            if (res == null)
                return null;
            return res.Adapt<TodoResult>();
        }
    }
}
