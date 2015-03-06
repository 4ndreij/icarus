using Icarus.Core.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public class ConfigureCommand : Command
    {
        readonly IDrone droneClient;
        DroneConfiguration.DroneConfiguration droneConfiguration;

        public ConfigureCommand(IDrone droneClient)
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
