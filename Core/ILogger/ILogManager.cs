using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ILogger
{
    public interface ILogManager<TClass>
    {
        public void LogWarning(string message, params object?[] args);
        public void LogError(string message, params object?[] args);
        public void LogFatal(string message, params object?[] args);
        public void LogInfo(string message, params object?[] args);
        public void LogVerbose(string message, params object?[] args);
        public void LogDebug(string message, params object?[] args);
    }
}
