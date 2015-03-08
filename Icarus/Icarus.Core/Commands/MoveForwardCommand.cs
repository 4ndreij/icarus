using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveForwardCommand : Command
    {
        readonly IDrone drone;

        public MoveForwardCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.MoveForward();
        }
    }
}
