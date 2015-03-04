using AR.Drone.Client.Command;
using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveUpCommand : Command
    {
        readonly IDroneClient droneClient;

        public MoveUpCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Progress(FlightMode.Progressive, gaz: 0.25f);
        }
    }
}
