using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveBackwardCommand : Command
    {
        readonly IDroneClient droneClient;

        public MoveBackwardCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveBackward();
        }
    }
}
