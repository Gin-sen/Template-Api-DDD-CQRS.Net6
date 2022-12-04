using MediatR;
using MY.DDD.CQRS.Temp6.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Contracts.WeatherAggregate.Notifications
{
    public class CreateWeatherWarningNotification : IEvent
    {
    public string Message { get; set; }
  }
}