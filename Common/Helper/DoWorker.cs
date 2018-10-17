using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StressTestPoc.Common.Helper {
    public class DoWorker {
        public int threadCount;
        public int actualWorkCount;

        public static long totalCount = 0;
        Stopwatch stopwatch = new Stopwatch();

        public DoWorker(int _threadCount, int _documnetCount) {
            threadCount = _threadCount;
            actualWorkCount = _documnetCount;
        }

        public void DoWork() {
            Logger.Info("<DoWorkerStart>");
            var documentListCount = new int[actualWorkCount];
            Parallel.ForEach(documentListCount, new ParallelOptions() { MaxDegreeOfParallelism = threadCount }, documentIndex => {
                ActualWork(Task.CurrentId.Value);
            });
            Logger.Info("</DoWorkerStart>");
        }
        public void ActualWork(int threadId) {
            try {
                Logger.Info("<WorkStart>");
                Console.WriteLine("Do your actual work call here. {0} : {1}", threadId, RandomGenerator.RandomString(6));
                Logger.Info("<WorkStart>");
            } catch(Exception ex) {
                Logger.Error("Failed", ex);
                Logger.Error(ex);
            }
            totalCount++;
            Logger.Info(string.Format("totalCount: {0} {1}", totalCount, Environment.NewLine + Environment.NewLine));

        }
    }
}
