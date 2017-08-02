using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;
using Microsoft.Practices.Unity;

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

                var eventBus = container.Resolve<IEventBus>();
                var queueClient = eventBus.Create("");

                queueClient.OnMessage((message) =>
                {
                    
                });
            });

        }
    }
}