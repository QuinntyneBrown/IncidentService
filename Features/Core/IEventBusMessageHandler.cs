namespace IncidentService.Features.Core
{
    public interface IEventBusMessageHandler
    {
        void Handle(IEventBusMessage message);
    }
}