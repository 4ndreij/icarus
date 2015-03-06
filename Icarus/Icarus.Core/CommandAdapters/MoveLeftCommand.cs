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
            droneClient.MoveLeft();
        }
    }
}
