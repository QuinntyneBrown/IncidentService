using System;
using System.Reactive.Subjects;

namespace IncidentService.Features.Core
{
    public class InMemoryEventBus : IEventBus
    {
        private Subject<IEventBusMessage> _subject = new Subject<IEventBusMessage>();

        public IQueueClient Create(string uri, string username = null, string password = null)
        {
            return new QueueClient(_subject);
        }

        public void Publish(IEventBusMessage message)
        {
            _subject.OnNext(message);
        }

        public class QueueClient : IQueueClient
        {
            public QueueClient(Subject<IEventBusMessage> subject)
            {
                _subject = subject;
            }

            public void OnMessage(Action<IEventBusMessage> action, IOnMessageOptions options = null)
            {
                _subject.Subscribe((message) =>
                {
                    action(message);
                });
            }

            private Subject<IEventBusMessage> _subject;
        }
    }
}