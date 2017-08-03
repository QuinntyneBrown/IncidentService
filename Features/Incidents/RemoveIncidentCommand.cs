using IncidentService.Data;
using IncidentService.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Data.Entity;
using System;

namespace IncidentService.Features.Incidents
{
    public class RemoveIncidentCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public int Id { get; set; }
            public Guid CorrelationId { get; set; }
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IncidentServiceContext context, IQueueClient queueClient)
            {
                _context = context;
                _queueClient = queueClient;
            }

            public async Task<Response> Handle(Request request)
            {
                var incident = await _context.Incidents.SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                incident.IsDeleted = true;
                await _context.SaveChangesAsync();

                _queueClient.Send(new RemovedIncidentMessage() {
                    TenantUniqueId = request.TenantUniqueId,
                    Payload = new {
                        Id = request.Id,
                        CorrelationId = request.CorrelationId
                    }
                });

                return new Response();
            }

            private readonly IncidentServiceContext _context;            
            private readonly IQueueClient _queueClient;
        }
    }
}
