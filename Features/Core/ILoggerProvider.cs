namespace IncidentService.Features.Core
{
    public interface ILoggerProvider
    {
        ILogger CreateLogger(string name);
    }
}
