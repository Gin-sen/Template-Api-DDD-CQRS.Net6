using My.DDD.CQRS.Temp6.Errors;
using My.DDD.CQRS.Temp6.Headers;
using My.DDD.CQRS.Temp6.Messaging.Configuration;
using My.DDD.CQRS.Temp6.Messaging.Headers;
using My.DDD.CQRS.Temp6.Messaging.Properties;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddMessagingHeaderContext(this IServiceCollection services)
  {
    services
      .AddNoDuplicateScoped<IHeaderContextAccessor, HeaderContextAccessor>();

    return services;
  }

  public static IServiceCollection AddMessagingOptions(this IServiceCollection services, IConfiguration? configuration)
  {
    var configurationSection = configuration?.GetSection("Messaging");
    var hasMessagingConnectionOptions = services.Any(service => service.ServiceType == typeof(IConfigureOptions<MessagingOptions>));

    if (configurationSection?.Exists() == true && !hasMessagingConnectionOptions)
    {
      services
        .AddOptions()
        .Configure<MessagingOptions>(configurationSection);
    }
    else if (!hasMessagingConnectionOptions)
    {
      throw new TechnicalException(Resources.MessagingNoConfigurationException);
    }

    return services;
  }
}