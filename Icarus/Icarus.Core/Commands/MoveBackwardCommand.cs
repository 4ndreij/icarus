using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveBackwardCommand : Command
    {
        readonly IDrone drone;

        public MoveBackwardCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.MoveBackward();
        }
    }
}
