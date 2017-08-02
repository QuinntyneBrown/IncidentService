using System;

namespace IncidentService
{
    public class SignalREventBus : IEventBus
    {
        public IQueueClient Create(string uri, string username = null, string password = null)
        {
            return new QueueClient();
        }

        public void Publish(dynamic @event)
        {
            
        }

        public class QueueClient : IQueueClient
        {            
            public void OnMessage(Action<dynamic> action, IOnMessageOptions options = null)
            {

            }
        }

    }
}