using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveRightCommand : Command
    {
        readonly IDrone droneClient;

        public MoveRightCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveRight();
        }
    }
}
