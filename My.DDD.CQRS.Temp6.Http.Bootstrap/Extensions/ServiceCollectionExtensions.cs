using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace My.DDD.CQRS.Temp6.Http.Bootstrap.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddHttpArchitecture(this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
  {
    if (assembly == null)
      assembly = Assembly.GetCallingAssembly();

    //.AddCommonArchitecture(configuration, assembly)
    //.AddHttpControllers()
    services.AddControllers();
    //.AddHubbixAuthentication()
    //.AddFrenchRouting()
    //.AddDefaultCors(configuration)
    //.AddForwardedHeaders()
    //.AddHttpHeaderContext()
    //.AddHeaderRequiredCapability()
    //.AddHttpIdentityContext()
    //.AddHttpMultitenancyContext()
    //.AddSerializers()
    //.AddHttpSerialization()
    //.AddDocumentation()
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    //.AddHttpErrors()
    services.AddHealthChecks();

    return services;
  }
}