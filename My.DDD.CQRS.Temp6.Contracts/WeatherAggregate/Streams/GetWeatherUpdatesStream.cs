using MediatR;

namespace My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Streams
{
    public class GetWeatherUpdatesStream : IStreamRequest<WeatherForecastResult>
    {
        public string City { get; set; }
    }
}
