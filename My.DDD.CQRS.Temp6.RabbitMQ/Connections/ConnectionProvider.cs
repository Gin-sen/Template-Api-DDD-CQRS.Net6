using My.DDD.CQRS.Temp6.RabbitMQ.Connections;
using RabbitMQ.Client;

namespace My.DDD.CQRS.Temp6.RabbitMQ.RabbitMQ.Connections;

public sealed class ConnectionProvider : IConnectionProvider, IDisposable
{
  private readonly IConnectionFactoryProvider connectionFactoryProvider;
  private IConnection? connection;

  public ConnectionProvider(IConnectionFactoryProvider connectionFactoryProvider)
  {
    this.connectionFactoryProvider = connectionFactoryProvider;
  }

  public IConnection Current => GetCurrent();

  private IConnection GetCurrent()
  {
    if (connection == null)
    {
      var connectionFactory = connectionFactoryProvider.Current;
      connection = connectionFactory.CreateConnection();
    }

    return connection;
  }

  public void Dispose()
  {
    if (connection != null)
      connection.Dispose();
  }
}
