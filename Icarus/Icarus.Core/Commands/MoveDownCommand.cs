using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveDownCommand : Command
    {
        readonly IDrone drone;

        public MoveDownCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.MoveDown();
        }
    }
}
