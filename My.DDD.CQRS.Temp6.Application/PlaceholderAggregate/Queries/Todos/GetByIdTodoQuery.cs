﻿using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Todos
{
    public class GetByIdTodoQuery : IRequestHandler<GetByIdTodo, TodoResult?>
    {
        private readonly IPlaceholderClient _placeholderClient;

        public GetByIdTodoQuery(IPlaceholderClient placeholderClient)
        {
            _placeholderClient = placeholderClient;
        }

        public async Task<TodoResult?> Handle(GetByIdTodo request, CancellationToken cancellationToken)
        {
            var res = await _placeholderClient.GetTodo(request.TodoId);
            if (res == null)
                return null;
            return new TodoResult() { Id = res.Id, UserId = res.UserId, Completed = res.Completed, Title = res.Title };
        }
    }
}