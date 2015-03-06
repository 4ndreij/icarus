using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveUpCommand : Command
    {
        readonly IDrone droneClient;

        public MoveUpCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveUp();
        }
    }
}
