using Microsoft.AspNet.SignalR.Hubs;

namespace IncidentService.Features.Core
{
    [HubName("eventHub")]
    public class EventHub: BaseHub
    {
    }
}