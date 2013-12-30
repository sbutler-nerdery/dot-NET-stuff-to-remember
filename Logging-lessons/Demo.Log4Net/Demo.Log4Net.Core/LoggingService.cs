using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace Demo.Log4Net.Core
{
    public class LoggingService
    {
        private static LoggingService _instance;

        private LoggingService()
        {
            XmlConfigurator.Configure();
        }

        public static LoggingService GetInstance()
        {
            return _instance ?? (_instance = new LoggingService());
        }

        public void LogError(Exception ex, Type logType)
        {
            log4net.ILog eventLogger = log4net.LogManager.GetLogger("EventLogger");
            log4net.ILog fileLogger = log4net.LogManager.GetLogger("FileLogger");
            eventLogger.Error("test error", ex);
            fileLogger.Error("test error", ex);            
        }
    }
}
