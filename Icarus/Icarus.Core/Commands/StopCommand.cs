using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class StopCommand : Command
    {
        readonly IDroneClient droneClient;

        public StopCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Stop();
        }
    }
}
