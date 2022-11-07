using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using My.DDD.CQRS.Temp6.CQRS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS
{
  public static class DependencyInjection
  {
    /// <summary>
    /// Add Classes dependencies
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException">services</exception>
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
      if (services == null)
        throw new ArgumentNullException(nameof(services));

      return services;
    }
  }
}
