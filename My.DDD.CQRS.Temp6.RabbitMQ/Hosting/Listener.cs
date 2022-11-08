using Hubbix.Common.Messaging.Headers;
using Hubbix.Common.Messaging.Hosting;
using Hubbix.Common.Messaging.RabbitMQ.Modeling;
using Hubbix.Common.Messaging.RabbitMQ.Replay;
using Hubbix.Common.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace My.DDD.CQRS.Temp6.RabbitMQ.Hosting;

public class Listener : IListener
{
  private readonly IModelProvider modelProvider;
  private readonly IBasicConsumerFactory basicConsumerFactory;
  private readonly IReplayStrategy? replayStrategy;
  private readonly ILogger<Listener> logger;
  private readonly string queueName;

  public Listener(
    IModelProvider modelProvider,
    IAssemblyAccessor assemblyAccessor,
    IBasicConsumerFactory basicConsumerFactory,
    ILogger<Listener> logger,
    IReplayStrategy? replayStrategy = null)
  {
    this.modelProvider = modelProvider;
    this.basicConsumerFactory = basicConsumerFactory;
    this.logger = logger;
    this.replayStrategy = replayStrategy;
    var assembly = assemblyAccessor.GetEntryAssembly();
    queueName = QueueNamer.GetQueueName(assembly);
  }

  public string? Tag { get; set; }

  public event EventHandler<MessageEventArgs>? Received;

  public void Listen()
  {
    var consumer = basicConsumerFactory.Build(modelProvider.Current);

    consumer.Received += ReceiveMessage;

    Tag = modelProvider.Current.BasicConsume(queueName, false, string.Empty, false, false, null, consumer);
  }

  public void ReceiveMessage(object? sender, BasicDeliverEventArgs e)
  {
    try
    {
      var message = new Message
      {
        Headers = TransfertHeaders(e),
        Body = Encoding.UTF8.GetString(e.Body.ToArray(), 0, e.Body.Length),
      };

      Received?.Invoke(this, new MessageEventArgs(message));

      modelProvider.Current.BasicAck(e.DeliveryTag, false);
    }
    catch (Exception ex)
    {
      logger.LogError(ex.GetBaseException(), null);

      if (replayStrategy != null)
      {
        try
        {
          replayStrategy.Replay(e, ex);
        }
        catch (Exception replayException)
        {
          logger.LogError(replayException, null);

          modelProvider.Current.BasicNack(e.DeliveryTag, false, false);
          var aggregateException = new AggregateException(ex, replayException);

          throw aggregateException;
        }
      }
      else
      {
        modelProvider.Current.BasicNack(e.DeliveryTag, false, false);
      }

      throw;
    }
    finally
    {
      if (modelProvider.Current.HasTransaction())
        modelProvider.Current.TxCommit();
    }
  }

  private static MessageHeaders TransfertHeaders(BasicDeliverEventArgs e)
  {
    var dictionary = e.BasicProperties.Headers
      .Where(header => !header.Key.StartsWith("x-"))
      .ToDictionary(x => x.Key, x => new StringValues(Encoding.UTF8.GetString((byte[])x.Value)));

    var result = new MessageHeaders(dictionary);

    return result;
  }

  public void StopListen()
  {
    if (!string.IsNullOrEmpty(Tag))
      modelProvider.Current.BasicCancel(Tag);

    Tag = null;
  }
}