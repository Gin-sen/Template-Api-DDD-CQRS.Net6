﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY.DDD.CQRS.Temp6.CQRS.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
  {
  }
}
