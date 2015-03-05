using AR.Drone.Client.Command;
using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveRightCommand : Command
    {
        readonly IDroneClient droneClient;

        public MoveRightCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Progress(FlightMode.Progressive, yaw: -0.25f);
        }
    }
}
