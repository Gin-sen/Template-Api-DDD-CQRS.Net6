﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS.Queries
{
  public interface IQueryRequest<out TResult> : IRequest<TResult> { }
}
