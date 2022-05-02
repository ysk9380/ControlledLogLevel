using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Serilog.Events;
using System.IO;
using System.Threading.Tasks;

namespace ControlledLogLevel
{
    internal class LogLevelSwitch
    {
        [FunctionName("ChangeLogLevel")]
        public async Task<IActionResult> ChangeLogLevelAsync(
          [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
          HttpRequest req)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrWhiteSpace(requestBody))
                return new BadRequestObjectResult("Level not specified.");

            switch (requestBody.ToLower())
            {
                case "verbose":
                    StartUp.LogLevelSwitch.MinimumLevel = LogEventLevel.Verbose;
                    break;
                case "debug":
                    StartUp.LogLevelSwitch.MinimumLevel = LogEventLevel.Debug;
                    break;
                case "information":
                    StartUp.LogLevelSwitch.MinimumLevel = LogEventLevel.Information;
                    break;
                case "warning":
                    StartUp.LogLevelSwitch.MinimumLevel = LogEventLevel.Warning;
                    break;
                case "error":
                    StartUp.LogLevelSwitch.MinimumLevel = LogEventLevel.Error;
                    break;
                case "fatal":
                    StartUp.LogLevelSwitch.MinimumLevel = LogEventLevel.Fatal;
                    break;
                default:
                    return new BadRequestObjectResult("Unknown level provided");
            }

            return new AcceptedResult();
        }
    }
}
