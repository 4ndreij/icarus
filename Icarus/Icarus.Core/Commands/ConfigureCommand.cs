using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public class ConfigureCommand : Command
    {
        IDroneClient droneClient;
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
