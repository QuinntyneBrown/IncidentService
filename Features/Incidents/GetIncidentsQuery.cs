using IncidentService.Data;
using IncidentService.Features.Core;
using IncidentService.Data.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace IncidentService.Features.Incidents
{
    public class GetIncidentsQuery
    {
        public class Request : BaseRequest, IRequest<Response> { }

        public class Response
        {
            public ICollection<IncidentApiModel> Incidents { get; set; } = new HashSet<IncidentApiModel>();
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IncidentServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var incidents = await _cache.FromCacheOrServiceAsync<List<Incident>>(() => _context.Incidents
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId )
                    .ToListAsync(), $"[Incidents] Get {request.TenantUniqueId}");

                return new Response()
                {
                    Incidents = incidents.Select(x => IncidentApiModel.FromIncident(x)).ToList()
                };
            }

            private readonly IncidentServiceContext _context;
            private readonly ICache _cache;
        }
    }
}
