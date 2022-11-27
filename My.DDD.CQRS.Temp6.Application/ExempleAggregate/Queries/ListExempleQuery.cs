﻿using MediatR;
using My.DDD.CQRS.Temp6.Contracts.ExempleAggregate.Queries;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.ExempleAggregate.Queries
{
  public class ListExempleQuery : IRequestHandler<ListExemple, IList<ExempleResult>>
  {
    private readonly IExempleRepository _exempleRepository;

    public ListExempleQuery(IExempleRepository exempleRepository)
    {
      _exempleRepository = exempleRepository;
    }

    public async Task<IList<ExempleResult>> Handle(ListExemple request, CancellationToken cancellationToken)
    {
      var result = await _exempleRepository.GetAllAsync(cancellationToken);
      var finalResult = new List<ExempleResult>();
      for (int i = 0; i < result.Count(); i++)
      {
        var element = result.ElementAt(i);
        finalResult.Add(new ExempleResult()
        {
          PartitionKey = element.PartitionKey,
          RowKey = element.RowKey,
          Increment = element.Increment,
          TimeStamp = element.Timestamp
        });
      }
      return finalResult;
    }
  }
}
