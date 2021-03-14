using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSV
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClientBase sv = new HttpClientBase();

            string ulrBase = System.Configuration.ConfigurationManager.AppSettings["ApiUrlBase"];
            string Action = System.Configuration.ConfigurationManager.AppSettings["ApiAction"];
            var obj = new WeatherForecastRq
            {
                Id = 1
            };
            sv.Exercute<WeatherForecastRq>("POST", ulrBase, Action, obj, null);

            string merchant = string.Empty;
            try
            {
                merchant = System.Configuration.ConfigurationManager.AppSettings["merchant"];
                Logger.LogInfor("//-----------------------------------------Start test service-----------------------------//");
                Console.WriteLine($"Start Sms service for merchant {merchant}.");

                Logger.LogInfor($"totalTaskSendAlias = {System.Configuration.ConfigurationManager.AppSettings["totalTaskSendAlias"]}.");
                Logger.LogInfor($"totalRequestPerTaskAlias = {System.Configuration.ConfigurationManager.AppSettings["totalRequestAlias"]}.");
                Logger.LogInfor($"totalTaskSend8149 = {System.Configuration.ConfigurationManager.AppSettings["totalTaskSend8149"]}.");
                Logger.LogInfor($"totalRequestPerTask8x49 = {System.Configuration.ConfigurationManager.AppSettings["totalRequest8x49"]}.");

                Console.WriteLine($"Test service for merchant: {merchant}.");
                Logger.LogInfor($"Test service for merchant: {merchant}.");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                switch (merchant)
                {
                    case "VPB":
                        {
                            var _testProcess = new TestProcessSendSsmsVPB();
                            _testProcess.Run();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"There is no merchant config.");
                            Logger.LogInfor($"There is no merchant config.");
                            break;
                        }
                }
                watch.Stop();

                var totalMilliSecond = watch.ElapsedMilliseconds;
                var totalSecond = watch.Elapsed.TotalSeconds.ToString();
                Console.WriteLine($"Test Sms service for merchant {merchant}  taken {totalSecond} Seconds.");
                Logger.LogInfor($"Test Sms service for merchant {merchant} taken {totalSecond} Seconds.");
                Console.WriteLine($"End Sms service for merchant {merchant}");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine($"Test Sms service for merchant {merchant} Exception.");
            }
        }
    }
}
