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
            droneClient.MoveRight();
        }
    }
}
