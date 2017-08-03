using Newtonsoft.Json.Linq;

namespace IncidentService.Features.Core
{
    public interface IEventBusMessageHandler
    {
        void Handle(JObject message);
    }
}