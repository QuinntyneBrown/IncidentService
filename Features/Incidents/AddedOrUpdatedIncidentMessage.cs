using IncidentService.Features.Core;

namespace IncidentService.Features.Incidents
{
    public class AddedOrUpdatedIncidentMessage : BaseEventBusMessage
    {        
        public override string Type { get; set; } = IncidentsEventBusMessages.AddedOrUpdatedIncidentMessage;        
    }
}