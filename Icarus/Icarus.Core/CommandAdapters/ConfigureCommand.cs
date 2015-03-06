using Icarus.Core.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public class ConfigureCommand : Command
    {
        readonly IDroneClient droneClient;
        DroneConfiguration.DroneConfiguration droneConfiguration;

        public ConfigureCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public void SetConfiguration(DroneConfiguration.DroneConfiguration droneConfiguration)
        {
            this.droneConfiguration = droneConfiguration;
        }

        public override void Execute()
        {
            droneClient.Configure(droneConfiguration);
        }
    }
}
