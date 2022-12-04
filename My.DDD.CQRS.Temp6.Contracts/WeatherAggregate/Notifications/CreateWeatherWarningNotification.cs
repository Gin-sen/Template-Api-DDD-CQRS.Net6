using MY.DDD.CQRS.Temp6.CQRS.Events;

namespace My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Notifications
{
    public class CreateWeatherWarningNotification : IEvent
    {
        public string Message { get; set; }
    }
}