using IncidentService.Features.Core;
using Microsoft.AspNet.SignalR;

namespace IncidentService.Features.Incidents
{
    public interface IIncidentsEventBusMessageHandler: IEventBusMessageHandler { }

    public class IncidentsEventBusMessageHandler: IIncidentsEventBusMessageHandler
    {
        public IncidentsEventBusMessageHandler(ICacheProvider cacheProvider)
        {
            _cache = cacheProvider.GetCache();
        }

        public void Handle(IEventBusMessage message)
        {
            if (message.Type == IncidentsEventBusMessages.AddedOrUpdatedIncidentMessage)
            {
                _cache.ClearAll();
            }

            if (message.Type == IncidentsEventBusMessages.RemovedIncidentMessage)
            {
                _cache.ClearAll();
            }
            
            GlobalHost.ConnectionManager.GetHubContext<EventHub>().Clients.All.events(message);
        }

        private readonly ICache _cache;
    }
}