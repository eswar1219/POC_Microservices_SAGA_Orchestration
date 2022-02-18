using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orchestrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Verbose()
                   .MinimumLevel.Information()
                   .MinimumLevel.Debug()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)

                   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)

                  .WriteTo.File(new JsonFormatter(), @"D:\demolog\logger.log")
                  .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
