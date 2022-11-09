﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS.Domain
{
  public interface IEntity : IEntity<int>
  {
  }

  public interface IEntity<TId> : IEntityBase
  {
    TId? Id { get; }
  }
}