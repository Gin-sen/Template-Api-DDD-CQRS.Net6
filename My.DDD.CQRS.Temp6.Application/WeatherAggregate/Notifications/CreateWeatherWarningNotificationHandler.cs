using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Notifications;
using MY.DDD.CQRS.Temp6.CQRS.Events;

namespace My.DDD.CQRS.Temp6.Application.WeatherAggregate.Notifications
{
    public class CreateWeatherWarningNotificationHandler : IEventHandler<CreateWeatherWarningNotification>
    {
        public async Task Handle(CreateWeatherWarningNotification notification, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);
            Console.WriteLine("Hello from CreateWeatherWarningNotification Handler");
        }
    }
}
