using Mapster;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Queries;
using My.DDD.CQRS.Temp6.Domain.WeatherAggregate;
using MY.DDD.CQRS.Temp6.CQRS.Queries;

namespace My.DDD.CQRS.Temp6.Application.WeatherAggregate.Queries
{
  public class GetWeatherForecastQueryHandler : IQueryHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecastResult>>
  {
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<IEnumerable<WeatherForecastResult>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
      await Task.Delay(500);
      var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      }).ToArray();
      var res = new List<WeatherForecastResult>();
      foreach (var element in result)
      {
        res.Add(element.Adapt<WeatherForecastResult>());
      }
      return res.AsEnumerable();
    }
  }
}
