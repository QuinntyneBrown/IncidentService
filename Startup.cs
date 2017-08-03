using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;
using Microsoft.Practices.Unity;
using System;
using IncidentService.Features.Core;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;
using Microsoft.ServiceBus.Messaging;

using static Newtonsoft.Json.JsonConvert;

[assembly: OwinStartup(typeof(IncidentService.Startup))]

namespace IncidentService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure((Action<HttpConfiguration>)(config =>
            {
                var container = UnityConfiguration.GetContainer();
                config.DependencyResolver = new UnityDependencyResolver(container);
                ApiConfiguration.Install(config, app);

                var incidentsEventBusMessageHandler = container.Resolve<Features.Incidents.IIncidentsEventBusMessageHandler>();
                var queueClient = container.Resolve<IQueueClient>();

                queueClient.OnMessage((message) =>
                {
                    var messageBody = ((BrokeredMessage)message).GetBody<string>();
                    var messageBodyObject = DeserializeObject<JObject>(messageBody);
                    incidentsEventBusMessageHandler.Handle(messageBodyObject);
                });
            }));
        }
    }
}