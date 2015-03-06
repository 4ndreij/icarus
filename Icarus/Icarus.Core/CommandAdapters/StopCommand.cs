using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class StopCommand : Command
    {
        readonly IDrone droneClient;

        public StopCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Stop();
        }
    }
}
