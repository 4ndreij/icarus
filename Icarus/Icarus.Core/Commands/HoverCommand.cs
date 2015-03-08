using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class HoverCommand : Command
    {
        private readonly IDrone drone;

        public HoverCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.Hover();
        }
    }
}