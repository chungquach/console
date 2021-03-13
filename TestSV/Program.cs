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
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Logger.LogInfor("//-----------------------------------------Start test service-----------------------------//");
            Console.WriteLine("Start test service");

            var _testProcess = new TestProcess();

            _testProcess.totalTaskSendAlias = int.Parse(System.Configuration.ConfigurationManager.AppSettings["totalTaskSendAlias"]);
            _testProcess.totalRequestAlias = int.Parse(System.Configuration.ConfigurationManager.AppSettings["totalRequestAlias"]);

            _testProcess.totalTaskSend8149 = int.Parse(System.Configuration.ConfigurationManager.AppSettings["totalTaskSend8149"]);
            _testProcess.totalRequest8x49 = int.Parse(System.Configuration.ConfigurationManager.AppSettings["totalRequest8x49"]);
            Logger.LogInfor($"totalTaskSend8149 = {_testProcess.totalTaskSend8149}");
            Logger.LogInfor($"totalRequestAlias = {_testProcess.totalRequestAlias}");
            Logger.LogInfor($"totalTaskSend8149 = {_testProcess.totalTaskSend8149}");
            Logger.LogInfor($"totalRequest8x49 = {_testProcess.totalRequest8x49}");

            _testProcess.Run();

            watch.Stop();
            var totalMilliSecond = watch.ElapsedMilliseconds;
            var sc = watch.Elapsed.TotalSeconds;
            Console.WriteLine($"Test service process taken {sc.ToString()} Seconds");
            Logger.LogInfor($"Test service process taken {sc.ToString()} Seconds");
            Console.WriteLine("End test service");
            Console.ReadKey();
        }
    }
}
