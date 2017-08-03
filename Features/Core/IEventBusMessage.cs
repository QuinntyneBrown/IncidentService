using System;

namespace IncidentService.Features.Core
{
    public interface IEventBusMessage
    {
        string Type { get; set; }
        dynamic Payload { get; set; }
        Guid TenantUniqueId { get; set; }
    }
}