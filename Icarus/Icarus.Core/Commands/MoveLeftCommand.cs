using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveLeftCommand : Command
    {
        readonly IDrone drone;

        public MoveLeftCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.MoveLeft();
        }
    }
}
