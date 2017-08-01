using System.Data.Entity.Migrations;
using IncidentService.Data;
using IncidentService.Data.Model;
using System;

namespace IncidentService.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(IncidentServiceContext context) {

            context.Tenants.AddOrUpdate(x => x.Name, new Tenant()
            {
                Name = "Default",
                UniqueId = new Guid("489902a0-a39d-4556-94b4-544d33d5ff5b")
            });

            context.SaveChanges();
        }
    }
}
