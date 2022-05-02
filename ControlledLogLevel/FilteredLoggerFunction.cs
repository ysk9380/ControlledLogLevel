using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlledLogLevel
{
    internal class FilteredLoggerFunction
    {
        private ILogger<FilteredLoggerFunction> _Logger { get; }
        private LoggingLevelSwitch _LogLevelSwitch { get; }

        internal FilteredLoggerFunction(ILogger<FilteredLoggerFunction> logger)
        {
            _Logger = logger;            
        }
        
        [FunctionName("GetFilteredLogs")]
        public void GetFilteredLogs(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
          HttpRequest req)
        {
            StartUp.LogLevelSwitch.MinimumLevel = LogEventLevel.Warning;

            _Logger.LogTrace("Trace Logged");
            _Logger.LogDebug("Debug Logged");
            _Logger.LogInformation("Information Logged");
            _Logger.LogWarning("Warning Logged");
            _Logger.LogError("Error Logged");
            _Logger.LogCritical("Fatal Logged");
        }
    }
}
