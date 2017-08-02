namespace IncidentService
{
    public interface IEventBus
    {
        IQueueClient Create(string uri, string username = null, string password = null);
        void Publish(dynamic @event);
    }
}
