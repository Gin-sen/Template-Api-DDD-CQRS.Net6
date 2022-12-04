using MediatR;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate;
using My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Streams;
using System.Runtime.CompilerServices;

namespace My.DDD.CQRS.Temp6.Application.WeatherAggregate.Streams
{
    public class GetWeatherUpdatesStreamHandler : IStreamRequestHandler<GetWeatherUpdatesStream, WeatherForecastResult>
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public async IAsyncEnumerable<WeatherForecastResult> Handle(GetWeatherUpdatesStream request,
          [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000, cancellationToken);
                var c = Random.Shared.Next(-20, 55);
                yield return new WeatherForecastResult
                {
                    Date = DateTime.Now,
                    TemperatureC = c,
                    TemperatureF = 32 + (int)(c / 0.5556),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            }
        }
    }
}
