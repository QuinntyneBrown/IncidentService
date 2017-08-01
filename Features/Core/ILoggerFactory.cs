using System.Collections.Generic;

namespace IncidentService.Features.Core
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string categoryName);

        List<ILoggerProvider> GetProviders();
    }
}
