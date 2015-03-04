using AR.Drone.Client.Command;
using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveLeftCommand : Command
    {
        readonly IDroneClient droneClient;

        public MoveLeftCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Progress(FlightMode.Progressive, yaw: 0.25f);
        }
    }
}
