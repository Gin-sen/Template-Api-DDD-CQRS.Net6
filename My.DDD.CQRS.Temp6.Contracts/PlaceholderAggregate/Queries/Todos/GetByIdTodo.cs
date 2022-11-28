using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos
{
    public class GetByIdTodo : IRequest<TodoResult?>
    {
        public int TodoId { get; set; }
    }
}
