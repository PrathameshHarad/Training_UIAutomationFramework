using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.IO;
using System.Reflection;

namespace UIAutomation.SeleniumCore.Utils
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Logger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        public static void Info(string message) => log.Info(message);
        public static void Warn(string message) => log.Warn(message);
        public static void Error(string message, Exception ex = null) => log.Error(message, ex);
        public static void Debug(string message) => log.Debug(message);
    }
}
