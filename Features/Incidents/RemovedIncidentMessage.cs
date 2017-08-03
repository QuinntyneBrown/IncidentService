using IncidentService.Features.Core;
using System;

namespace IncidentService.Features.Incidents
{
    public class RemovedIncidentMessage : IEventBusMessage
    {
        public dynamic Payload { get; set; }

        public string Type { get; set; } = IncidentsEventBusMessages.RemovedIncidentMessage;

        public Guid TenantUniqueId { get; set; }
    }
}