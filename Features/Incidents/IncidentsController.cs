using IncidentService.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace IncidentService.Features.Incidents
{
    [RoutePrefix("api/incidents")]
    public class IncidentController : BaseApiController
    {
        public IncidentController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateIncidentCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateIncidentCommand.Request request)
            => Ok(await Send(request));
        
        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateIncidentCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateIncidentCommand.Request request)
            => Ok(await Send(request));
                
        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(GetIncidentsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetIncidentsQuery.Request()));
        
        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetIncidentByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetIncidentByIdQuery.Request request)
            => Ok(await Send(request));
        
        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveIncidentCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveIncidentCommand.Request request)
            => Ok(await Send(request));        
        
    }
}