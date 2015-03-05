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
            droneClient.MoveForward();
        }
    }
}
