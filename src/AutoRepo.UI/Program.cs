using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoRepo.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //config.Sources.Clear();

                    //var env = hostingContext.HostingEnvironment;

                    //config.AddIniFile("MyIniConfig.ini", optional: true, reloadOnChange: true)
                    //    .AddIniFile($"MyIniConfig.{env.EnvironmentName}.ini",
                    //        optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    //File.AppendAllText($"{Directory.GetCurrentDirectory()}/data/{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.log","App begin");
                });
    }
}
