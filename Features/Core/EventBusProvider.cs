using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentService.Features.Core
{
    public interface IEventBusProvider {
        IEventBus GetEventBus();
    }

    public class EventBusProvider : IEventBusProvider
    {
        public IEventBus GetEventBus()
        {
            return InMemoryEventBus.Instance;
        }
    }
}