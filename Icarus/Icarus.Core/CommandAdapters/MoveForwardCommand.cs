using AR.Drone.Client.Command;
using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveForwardCommand : Command
    {
        readonly IDroneClient droneClient;

        public MoveForwardCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Progress(FlightMode.Progressive, pitch: -0.05f);
        }
    }
}
