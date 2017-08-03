namespace IncidentService.Features.Core
{
    public interface IEventBus
    {
        IQueueClient Create(string uri, string username = null, string password = null);
        void Publish(IEventBusMessage @event);
    }
}
