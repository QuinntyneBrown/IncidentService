using MediatR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IncidentService.Features.Core;

namespace IncidentService.Features.Incidents
{
    [Authorize]
    [RoutePrefix("api/incidents")]
    public class IncidentController : ApiController
    {
        public IncidentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateIncidentCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateIncidentCommand.Request request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateIncidentCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateIncidentCommand.Request request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetIncidentsQuery.Response))]
        public async Task<IHttpActionResult> Get()
        {
            var request = new GetIncidentsQuery.Request();
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetIncidentByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetIncidentByIdQuery.Request request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveIncidentCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveIncidentCommand.Request request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        protected readonly IMediator _mediator;
    }
}
