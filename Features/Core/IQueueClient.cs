using System;

namespace IncidentService.Features.Core
{
    public interface IQueueClient
    {
        void OnMessage(Action<IEventBusMessage> action, IOnMessageOptions options = null);
    }
}