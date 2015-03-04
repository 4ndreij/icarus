using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class StartCommand : Command
    {
        readonly IDroneClient droneClient;

        public StartCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Takeoff();
        }
    }
}
