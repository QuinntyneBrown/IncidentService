using System;

namespace IncidentService.Features.Core
{
    public class BaseRequest 
    {
        public Guid TenantUniqueId { get; set; }
    }
}