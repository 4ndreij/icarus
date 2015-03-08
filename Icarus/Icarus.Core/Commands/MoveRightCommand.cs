using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveRightCommand : Command
    {
        readonly IDrone drone;

        public MoveRightCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.MoveRight();
        }
    }
}
