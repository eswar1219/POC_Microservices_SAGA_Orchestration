using Serilog;
using Serilog.Formatting.Json;
using System;

namespace AppLogger
{
    public static class Utility
    {
        public static void WriteLog(string message, object obj)
        {
            //Log.Logger = new LoggerConfiguration()
            //      .MinimumLevel.Verbose()
            //      .WriteTo.File(new JsonFormatter(), @"D:\demolog\logger.log")
            //      .CreateLogger();

            //Log.Information(message, obj);
        }
    }
}
