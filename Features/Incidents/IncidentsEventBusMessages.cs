namespace IncidentService.Features.Incidents
{
    public class IncidentsEventBusMessages
    {
        public static string AddedOrUpdatedIncidentMessage = "[Incidents] IncidentAddedOrUpdated";
        public static string RemovedIncidentMessage = "[Incidents] IncidentRemoved";
    }
}