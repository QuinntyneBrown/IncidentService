using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace IncidentService.Features.Core
{
    public class BaseApiController : ApiController
    {
        protected Guid TenantUniqueId { get {
                return new Guid(Request.GetQueryNameValuePairs().SingleOrDefault(x => x.Key == "Tenant").Value);
            }
        }
    }
}
