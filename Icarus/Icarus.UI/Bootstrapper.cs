using Icarus.Infrastructure.InputProviders;
using StructureMap;
using Icarus.Core.Interfaces;
using log4net;
using Icarus.Infrastructure.CommandFactory;
using Icarus.Infrastructure.Communication;
using Icarus.ParrotDrone;
using AR.Drone.Client;

namespace Icarus.UI
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var droneClient = new DroneClient();
            var logger = ConfigureLogger();
            var container = new Container(x =>
            {
                x.For<ILog>().Use(logger);
                x.For<DroneClient>().Use(droneClient);
                x.For<IDrone>().UseSpecial(y => y.ConstructedBy(_ => new ParrotDrone.ParrotDrone(droneClient)));
                x.For<ICommandFactory>().Use<CommandFactory>();
                x.For<ICommunicator>().Use<CommandInvoker>();
                x.For<IInputProviderAdapter>().Use<Drone>();
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
