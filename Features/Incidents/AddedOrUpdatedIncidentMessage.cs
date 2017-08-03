using IncidentService.Features.Core;
using System;

namespace IncidentService.Features.Incidents
{
    public class AddedOrUpdatedIncidentMessage : IEventBusMessage
    {
        public dynamic Payload { get; set; }

        public string Type { get; set; } = IncidentsEventBusMessages.AddedOrUpdatedIncidentMessage;

        public Guid TenantUniqueId { get; set; }
    }
}