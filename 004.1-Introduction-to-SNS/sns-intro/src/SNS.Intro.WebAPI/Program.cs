using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SNS.Intro.WebAPI
{
   public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            
            try
            {
                
                Log.Information("Starting web host");
                CreateWebHost(args).Run();
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                Environment.Exit(1);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHost CreateWebHost(string[] args)
        {
            return new HostBuilder().
                ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseSerilog();
                    webBuilder.UseStartup<Startup>();
                })
                .Build();
        }
    }
}