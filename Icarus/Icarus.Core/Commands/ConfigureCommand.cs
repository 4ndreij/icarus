using Icarus.Core.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public class ConfigureCommand : Command
    {
        readonly IDrone drone;
        DroneConfiguration.DroneConfiguration droneConfiguration;

        public ConfigureCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public void SetConfiguration(DroneConfiguration.DroneConfiguration droneConfiguration)
        {
            this.droneConfiguration = droneConfiguration;
        }

        public override void Execute()
        {
            drone.Configure(droneConfiguration);
        }
    }
}
