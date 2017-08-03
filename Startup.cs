using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;
using Microsoft.Practices.Unity;
using System;
using IncidentService.Features.Core;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(IncidentService.Startup))]

namespace IncidentService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(config =>
            {
                var container = UnityConfiguration.GetContainer();
                config.DependencyResolver = new UnityDependencyResolver(container);
                ApiConfiguration.Install(config, app);

                var bus = container.Resolve<IEventBus>();
                var incidentsEventBusMessageHandler = container.Resolve<Features.Incidents.IIncidentsEventBusMessageHandler>();
                
                var queueClient = bus.Create("");

                queueClient.OnMessage((message) =>
                {
                    incidentsEventBusMessageHandler.Handle(message);
                });                
            });
        }
    }
}