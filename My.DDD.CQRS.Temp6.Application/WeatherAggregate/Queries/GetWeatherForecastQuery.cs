using MediatR;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Queries;
using My.DDD.CQRS.Temp6.Domain.WeatherAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Application.WeatherAggregate.Queries
{
    public class GetWeatherForecastQuery : IRequestHandler<GetWeatherForecast, IEnumerable<WeatherForecastResult>>
  {
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<IEnumerable<WeatherForecastResult>> Handle(GetWeatherForecast request, CancellationToken cancellationToken)
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
        res.Add(new() { Date= element.Date, Summary= element.Summary, TemperatureC = element.TemperatureC, TemperatureF = element.TemperatureF });
      }
      return res.AsEnumerable();
    }
  }
}
