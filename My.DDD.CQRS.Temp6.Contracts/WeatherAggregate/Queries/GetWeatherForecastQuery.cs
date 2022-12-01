using MediatR;
using My.DDD.CQRS.Temp6.Domain.WeatherAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Queries
{
    public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecastResult>>
    {
    }
}
