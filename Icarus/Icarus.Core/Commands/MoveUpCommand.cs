using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveUpCommand : Command
    {
        readonly IDrone drone;

        public MoveUpCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.MoveUp();
        }
    }
}
