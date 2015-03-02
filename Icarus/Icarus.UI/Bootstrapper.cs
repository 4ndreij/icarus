using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using Icarus.Core.Interfaces;
using log4net;
using Icarus.Infrastructure.CommandFactory;
using Icarus.Core.DroneClients;
using Icarus.Infrastructure.Communication;

namespace Icarus.UI
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var logger = ConfigureLogger();
            var container = new Container(x =>
            {
                x.For<ILog>().Use(logger);
                x.For<IDroneClient>().Use<WifiClient>();
                x.For<ICommandFactory>().Use<CommandFactory>();
                x.For<ICommunicator>().Use<CommandInvoker>();
            });
            return container;
        }

        ILog ConfigureLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
            return LogManager.GetLogger("DroneLogger");
        }
    }
}
