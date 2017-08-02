using MediatR;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace IncidentService.Features.Core
{
    public class BaseApiController : ApiController
    {
        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected Guid TenantUniqueId { get {
                return new Guid(Convert.ToString(Request.Headers.GetValues("Tenant").Single()));
            }
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request) {            
            PropertyInfo prop = request.GetType().GetProperty("TenantUniqueId", BindingFlags.Public | BindingFlags.Instance);
            prop.SetValue(request, TenantUniqueId, null);
            return _mediator.Send(request);
        }

        private IMediator _mediator;
    }
}
