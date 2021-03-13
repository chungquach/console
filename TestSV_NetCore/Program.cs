using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TestSV_NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder();
                BuildConfiguration(builder);

                var host = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {
                        services.AddTransient<ITest, Test>()
                        .AddSingleton(typeof(ILogger<>), typeof(Logger<>))
                        .AddLogging()
                        .BuildServiceProvider();

                    })
                    .Build();

                var sv = ActivatorUtilities.CreateInstance<Test>(host.Services);
                sv.run();
            }
            catch (Exception eex)
            {
                throw;
            }
        }

        static void BuildConfiguration(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                    .AddEnvironmentVariables();
        }
    }
    public class Test : ITest
    {
        private readonly ILogger<Test> _log;
        private readonly IConfiguration _config;

        public Test(ILogger<Test> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }
        public void run()
        {
            _log.LogInformation("AAAAA");
            for (int i = 0; i < 10; i++)
            {
                _log.LogInformation(i.ToString());
            }
        }
    }
    public interface ITest
    {
        void run();
    }
}
