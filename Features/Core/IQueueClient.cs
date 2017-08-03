using System;

namespace IncidentService.Features.Core
{
    public interface IQueueClient
    {
        void OnMessage(Action<dynamic> callback);
        void Send(dynamic message);
    }
}