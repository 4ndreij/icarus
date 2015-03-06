using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveDownCommand : Command
    {
        readonly IDrone droneClient;

        public MoveDownCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveDown();
        }
    }
}
