using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveBackwardCommand : Command
    {
        readonly IDrone droneClient;

        public MoveBackwardCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveBackward();
        }
    }
}
