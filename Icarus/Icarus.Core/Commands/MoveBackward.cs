using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveBackward : Command
    {
        readonly IDroneClient droneClient;

        public MoveBackward(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveBackward();
        }
    }
}
