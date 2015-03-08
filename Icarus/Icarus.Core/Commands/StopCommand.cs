using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class StopCommand : Command
    {
        readonly IDrone drone;

        public StopCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.Stop();
        }
    }
}
