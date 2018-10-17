using System;

namespace StressTestPoc.Common.Helper {
    public static class Logger {

        private static log4net.ILog Log { get; set; }

        static Logger() {
            Log = log4net.LogManager.GetLogger(typeof(Logger));
        }

        public static void Error(object msg, Exception ex) {
            Log.Error(msg, ex);
        }

        public static void Error(Exception ex) {
            Log.Error(ex.Message, ex);
        }

        public static void Info(string message) {
            Log.Info(message);
        }

    }
}
