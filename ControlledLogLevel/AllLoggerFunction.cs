using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace ControlledLogLevel
{
    internal class AllLoggerFunction
    {
        private ILogger<AllLoggerFunction> _Logger { get; }

        internal AllLoggerFunction(ILogger<AllLoggerFunction> logger)
        {
            _Logger = logger;
        }


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
