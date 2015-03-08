using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class StartCommand : Command
    {
        readonly IDrone drone;

        public StartCommand(IDrone drone)
        {
            this.drone = drone;
        }

        public override void Execute()
        {
            drone.Start();
        }
    }
}
