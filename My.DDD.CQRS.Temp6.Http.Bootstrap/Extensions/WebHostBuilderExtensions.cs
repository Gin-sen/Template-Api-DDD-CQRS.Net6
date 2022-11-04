using System.Reflection;
using My.DDD.CQRS.Temp6.Reflection.Extensions;
using My.DDD.CQRS.Temp6.Logging.Extensions;
using Microsoft.AspNetCore.Hosting;

namespace My.DDD.CQRS.Temp6.Http.Bootstrap.Extensions;

public static class WebHostBuilderExtensions
{
  public static IWebHostBuilder UseHttp<TStartup>(this IWebHostBuilder hostBuilder, Assembly? assembly = null)
      where TStartup : class
  {
    if (assembly == null)
      assembly = Assembly.GetCallingAssembly();

    var result = hostBuilder
      .LoadAssemblyReferencedNotLoaded(assembly);

    return result;
  }
}