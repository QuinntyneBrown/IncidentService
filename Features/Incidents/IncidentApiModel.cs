using IncidentService.Data.Model;

namespace IncidentService.Features.Incidents
{
    public class IncidentApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }

        public static TModel FromIncident<TModel>(Incident incident) where
            TModel : IncidentApiModel, new()
        {
            var model = new TModel();
            model.Id = incident.Id;
            model.TenantId = incident.TenantId;
            model.Name = incident.Name;
            return model;
        }

        public static IncidentApiModel FromIncident(Incident incident)
            => FromIncident<IncidentApiModel>(incident);

    }
}
