using Icarus.Core.Interfaces;

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
