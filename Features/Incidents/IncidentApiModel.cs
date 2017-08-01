using IncidentService.Data.Model;
using System;

namespace IncidentService.Features.Incidents
{
    public class IncidentApiModel
    {        
        public int Id { get; set; }

        public int? TenantId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ReportedBy { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? ClosedOn { get; set; }

        public static TModel FromIncident<TModel>(Incident incident) where
            TModel : IncidentApiModel, new()
        {
            var model = new TModel();
            model.Id = incident.Id;
            model.TenantId = incident.TenantId;
            model.Name = incident.Name;
            model.Description = incident.Description;
            model.ReportedBy = incident.ReportedBy;
            model.IsClosed = incident.IsClosed;
            model.ClosedOn = incident.ClosedOn;
            return model;
        }

        public static IncidentApiModel FromIncident(Incident incident)
            => FromIncident<IncidentApiModel>(incident);

    }
}
