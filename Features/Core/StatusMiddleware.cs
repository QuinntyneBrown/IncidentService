﻿using Microsoft.Owin;
using System.Threading.Tasks;

namespace IncidentService.Features.Core
{
    public class StatusMiddleware : OwinMiddleware
    {
        public StatusMiddleware(OwinMiddleware next)
            : base(next) { }

        public override async Task Invoke(IOwinContext context)
        {
            if (context.Request.Uri.AbsoluteUri.EndsWith("/status"))
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("ok");
                return;
            }

            await Next.Invoke(context);
        }
    }
}
