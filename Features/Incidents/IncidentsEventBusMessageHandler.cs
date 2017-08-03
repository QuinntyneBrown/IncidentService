﻿using IncidentService.Features.Core;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;
using System;

namespace IncidentService.Features.Incidents
{
    public interface IIncidentsEventBusMessageHandler: IEventBusMessageHandler { }

    public class IncidentsEventBusMessageHandler: IIncidentsEventBusMessageHandler
    {
        public IncidentsEventBusMessageHandler(ICacheProvider cacheProvider)
        {
            _cache = cacheProvider.GetCache();
        }

        public void Handle(JObject message)
        {
            try
            {
                if ($"{message["Type"]}" == IncidentsEventBusMessages.AddedOrUpdatedIncidentMessage)
                {
                    _cache.ClearAll();
                }

                if ($"{message["Type"]}" == IncidentsEventBusMessages.RemovedIncidentMessage)
                {
                    _cache.ClearAll();
                }

                GlobalHost.ConnectionManager.GetHubContext<EventHub>().Clients.All.events(message);

            }
            catch (Exception e)
            {

            }
        }

        private readonly ICache _cache;
    }
}