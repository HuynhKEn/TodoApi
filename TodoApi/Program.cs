using System;
using TodoApi.Core.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TodoApi {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(builder =>
                    builder.ClearProviders()
                        .AddColorConsoleLogger(configuration => {
                            configuration.LogLevels.Add(
                                LogLevel.Warning, ConsoleColor.DarkMagenta);
                            configuration.LogLevels.Add(
                                LogLevel.Error, ConsoleColor.Red);
                        }))
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
