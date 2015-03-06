using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class HoverCommand : Command
    {
        private readonly IDrone droneClient;

        public HoverCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Hover();
        }
    }
}