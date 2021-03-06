using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace SerilogImplementation
{
    public class Program
    {
        /// <summary>
        /// Note: While using serilog use either appsettings.json or code config. 
        /// It's best practice for using serilog settings from appsettings.json.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //First bring appsetting.json settings
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            var configBuilder = builder.Build();


            //Then, Create serilog for logging
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                //.WriteTo.File(Path.Combine("Logs" , "library-log-.log"), rollingInterval: RollingInterval.Day) //You can use this instead of appsetting.json but not recomended.
                .ReadFrom.Configuration(configBuilder)
                .CreateLogger();

            try
            {
                Log.Information("Application Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() //Use serilog after autofac
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
