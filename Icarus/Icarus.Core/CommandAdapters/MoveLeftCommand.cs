using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveLeftCommand : Command
    {
        readonly IDrone droneClient;

        public MoveLeftCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveLeft();
        }
    }
}
