using System;

namespace IncidentService
{
    public interface IQueueClient
    {
        void OnMessage(Action<dynamic> action, IOnMessageOptions options = null);
    }
}