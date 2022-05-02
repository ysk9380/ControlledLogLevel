using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlledLogLevel
{
    internal class AllLoggerFunction
    {
        public AllLoggerFunction(ILogger<AllLoggerFunction> logger)
        {
            _Logger = logger;
        }

        public ILogger<AllLoggerFunction> _Logger { get; }

        [FunctionName("GetAllLogs")]
        public void GetAllLogs(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
          HttpRequest req)
        {
            _Logger.LogTrace("Trace Logged");
            _Logger.LogDebug("Debug Logged");
            _Logger.LogInformation("Information Logged");
            _Logger.LogWarning("Warning Logged");
            _Logger.LogError("Error Logged");
            _Logger.LogCritical("Fatal Logged");
        }
    }
}
