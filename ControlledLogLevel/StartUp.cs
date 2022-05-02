using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;

[assembly: FunctionsStartup(typeof(ControlledLogLevel.StartUp))]

namespace ControlledLogLevel
{
    
    public class StartUp : FunctionsStartup
    {
        public static LoggingLevelSwitch LogLevelSwitch { get; private set; }
        
        public override void Configure(IFunctionsHostBuilder builder)
        {
            LogLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Verbose);

            builder.Services.AddLogging(configure =>
            {  
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.ControlledBy(LogLevelSwitch)
                    .WriteTo.Console()
                    .CreateLogger();

                configure.AddSerilog(Log.Logger);
            });
        }
    }
}
