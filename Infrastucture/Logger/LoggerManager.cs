using Core.ILogger;
using Microsoft.Extensions.Logging;

namespace Infrastucture.Logger
{
    public class LoggerManager<TClass> : ILogManager<TClass>
    {
        private readonly ILogger<TClass> _logger;

        public LoggerManager(ILogger<TClass> logger)
        {
            _logger = logger;
        }

        public void LogDebug(string mesasge, params object?[] args)
        {
            _logger.LogDebug(mesasge, args);
        }

        public void LogError(string message, params object?[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogFatal(string message, params object?[] args)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message, params object?[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogVerbose(string message, params object?[] args)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message, params object?[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
