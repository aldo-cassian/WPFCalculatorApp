using log4net;
using log4net.Config;
using System;
using System.Diagnostics;
using System.IO;

namespace WPFCalculatorApp.Logging
{
    public static class LogHelper
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LogHelper));

        static LogHelper()
        {
            // Load config manually from file
            var logConfig = new FileInfo("log4net.config");
            if (logConfig.Exists)
            {
                XmlConfigurator.ConfigureAndWatch(logConfig);
            }
            else
            {
                // Optional fallback
                Debug.WriteLine("Log configuration file not found.");
            }

        }

        public static void Log(string message)
        {
            logger.Info(message);
        }
    }
}
