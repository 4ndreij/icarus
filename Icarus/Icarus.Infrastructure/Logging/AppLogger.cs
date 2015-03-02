using Icarus.Core.Interfaces;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Infrastructure.Logging
{
    public class AppLogger : IAppLogger
    {
        readonly ILog logger;

        public AppLogger(string configFilePath)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(configFilePath));
            logger = LogManager.GetLogger("DroneLogger");
        }

        public void LogInfo(string subject, string message)
        {
            logger.Info("======== INFO ========");
            logger.Info(string.Format("Subject: {0} Message: {1}", subject, message));
            logger.Info("======== END INFO ========");
        }

        public void LogError(string subject, string message, Exception ex)
        {
            logger.Info("======== ERROR ========");
            logger.Info(string.Format("Subject: {0} Message: {1}\nException details: {2}", 
                subject, message, ex));
            logger.Info("======== END ERROR ========");
        }
    }
}
