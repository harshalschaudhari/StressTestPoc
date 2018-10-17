using StressTestPoc.Common.Helper;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace StressTestPoc {
    class Program {
        public static string containerName;
        public static async Task Main(string[] args) {

            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                       typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            #region "New Start"
            Console.WriteLine("<MainStart>");
            DoWorker doWorker;
            Console.WriteLine("How many thread you want to start?:");
            int threadcount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many work you want to do?:");
            int actualWorkCount = Convert.ToInt32(Console.ReadLine());

            doWorker = new DoWorker(threadcount, actualWorkCount);
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing.
            stopwatch.Start();
            try {
                doWorker.DoWork();
            } catch(Exception ex) {
                Logger.Error("From Main", ex);
            }
            // Stop timing.
            stopwatch.Stop();
            Logger.Info("TakenTime: " + stopwatch.Elapsed.ToString());
            Logger.Info("</MainStart>");
            Console.ReadLine();
            #endregion
            Console.ReadKey();
        }

    }
}
