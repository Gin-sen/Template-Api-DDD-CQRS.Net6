﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddContractsLayer(this IServiceCollection services)
    {

      services.AddMediatR(typeof(DependencyInjection).Assembly);

      return services;
    }
  }
}