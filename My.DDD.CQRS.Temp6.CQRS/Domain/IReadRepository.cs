﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS.Domain
{
  public interface IReadRepository<TEntity>
  where TEntity : IEntityBase
  {
    IQueryable<TEntity> GetAll();
  }

}