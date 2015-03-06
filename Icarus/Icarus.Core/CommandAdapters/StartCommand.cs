using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class StartCommand : Command
    {
        readonly IDrone droneClient;

        public StartCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Start();
        }
    }
}
