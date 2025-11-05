using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;

namespace UIAutomation.SeleniumCore.Utils
{
    public static class Logger
    {
        private static readonly ILog log;

        static Logger()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            var patternLayout = new PatternLayout
            {
                ConversionPattern = "[%date] [%level] %logger - %message%newline"
            };
            patternLayout.ActivateOptions();

            var consoleAppender = new ConsoleAppender
            {
                Layout = patternLayout
            };
            consoleAppender.ActivateOptions();

            var fileAppender = new RollingFileAppender
            {
                AppendToFile = true,
                File = "Logs/TestAutomation.log",
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "5MB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true
            };
            fileAppender.ActivateOptions();

            hierarchy.Root.AddAppender(consoleAppender);
            hierarchy.Root.AddAppender(fileAppender);

            hierarchy.Root.Level = log4net.Core.Level.Debug;
            hierarchy.Configured = true;

            log = LogManager.GetLogger(typeof(Logger));
        }

        public static void Info(string message) => log.Info(message);
        public static void Debug(string message) => log.Debug(message);
        public static void Warn(string message) => log.Warn(message);
        public static void Error(string message, Exception ex = null) => log.Error(message, ex);
    }
}
