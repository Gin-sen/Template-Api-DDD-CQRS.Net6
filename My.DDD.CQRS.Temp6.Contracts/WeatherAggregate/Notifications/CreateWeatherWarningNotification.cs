using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Notifications
{
    public class CreateWeatherWarningNotification : INotification
    {
    public string Message { get; set; }
  }
}