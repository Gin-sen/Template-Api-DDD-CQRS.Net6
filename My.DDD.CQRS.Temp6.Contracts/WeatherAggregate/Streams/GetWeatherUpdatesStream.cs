using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Streams
{
  public class GetWeatherUpdatesStream : IStreamRequest<WeatherForecastResult>
  {
    public string City { get; set; }
  }
}
