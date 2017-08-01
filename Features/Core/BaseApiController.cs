using System;
using System.Web.Http;

namespace IncidentService.Features.Core
{
    public class BaseApiController : ApiController
    {
        protected Guid TenantUniqueId { get {return Request.GetTenantUniqueId(); } }
    }
}
