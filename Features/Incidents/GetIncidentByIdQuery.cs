using MediatR;
using IncidentService.Data;
using IncidentService.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace IncidentService.Features.Incidents
{
    public class GetIncidentByIdQuery
    {
        public class Request : BaseRequest, IRequest<Response> { 
            public int Id { get; set; }
        }

        public class Response
        {
            public IncidentApiModel Incident { get; set; } 
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
                return new Response()
                {
                    Incident = IncidentApiModel.FromIncident(await _context.Incidents
                    .Include(x => x.Tenant)				
					.SingleAsync(x=>x.Id == request.Id &&  x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly IncidentServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
