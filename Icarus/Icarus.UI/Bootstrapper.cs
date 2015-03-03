using Icarus.Infrastructure.InputProviders;
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
                x.For<IInputProvider>().Use<KeyboardInputProvider>();
                x.For<IInputProviderAdapter>().Use<IInputProviderAdapter>();
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
