using MediatR;
using IncidentService.Data;
using IncidentService.Data.Model;
using IncidentService.Features.Core;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IncidentService.Features.Incidents
{
    public class AddOrUpdateIncidentCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public IncidentApiModel Incident { get; set; }
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IncidentServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Incidents
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Incident.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Incidents.Add(entity = new Incident() { TenantId = tenant.Id });
                }

                entity.Name = request.Incident.Name;
                entity.Description = request.Incident.Description;
                entity.ReportedBy = request.Incident.ReportedBy;
                entity.IsClosed = request.Incident.IsClosed;
                entity.ClosedOn = request.Incident.ClosedOn;
                
                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly IncidentServiceContext _context;
            private readonly ICache _cache;
        }
    }
}
