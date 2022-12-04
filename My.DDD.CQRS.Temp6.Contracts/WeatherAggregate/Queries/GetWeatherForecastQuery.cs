using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Queries
{
    public class GetWeatherForecastQuery : IQuery<IEnumerable<WeatherForecastResult>>
    {
    }
}
