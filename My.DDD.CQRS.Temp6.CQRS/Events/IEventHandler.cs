﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.CQRS.Events
{
  public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
  where TEvent : IEvent
  {
  }
}