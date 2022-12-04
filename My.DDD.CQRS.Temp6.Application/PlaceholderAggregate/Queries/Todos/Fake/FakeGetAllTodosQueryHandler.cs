﻿using MediatR;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos.Fake;
using My.DDD.CQRS.Temp6.Contracts.PlaceholderAggregate.Queries.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.DDD.CQRS.Temp6.DBAccess;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.PlaceholderAggregate.Queries.Todos.Fake
{
  public class FakeGetAllTodosQueryHandler : IQueryHandler<FakeGetAllTodosQuery, IEnumerable<TodoResult>>
  {
    private readonly FakeBdContext _fakeDbContext;
    public FakeGetAllTodosQueryHandler(FakeBdContext fakeDbContext)
    {
      _fakeDbContext = fakeDbContext;
    }

    public async Task<IEnumerable<TodoResult>> Handle(FakeGetAllTodosQuery request, CancellationToken cancellationToken)
    {

      var result = await _fakeDbContext.GetAllTodos();
      var finalResult = new List<TodoResult>();
      for (int i = 0; i < result.Count(); i++)
      {
        var res = result.ElementAt(i);
        finalResult.Add(new TodoResult() { Id = res.Id, UserId = res.UserId, Completed = res.Completed, Title = res.Title });
      }
      return finalResult;
    }
  }
}
