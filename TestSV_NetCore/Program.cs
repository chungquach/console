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
                Startup.BuildConfiguration(builder);



              
            }
            catch
            {
            }
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
