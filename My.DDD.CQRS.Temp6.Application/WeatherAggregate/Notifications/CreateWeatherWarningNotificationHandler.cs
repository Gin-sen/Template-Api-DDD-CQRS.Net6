using MediatR;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.WeatherAggregate.Notifications
{
  public class CreateWeatherWarningNotificationHandler : INotificationHandler<CreateWeatherWarningNotification>
  {
    public async Task Handle(CreateWeatherWarningNotification notification, CancellationToken cancellationToken)
    {
      await Task.Delay(1000);
      Console.WriteLine("Hello from CreateWeatherWarningNotification Handler");
    }
  }
}
