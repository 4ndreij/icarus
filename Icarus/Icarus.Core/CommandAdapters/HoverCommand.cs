using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class HoverCommand : Command
    {
        private readonly IDroneClient droneClient;

        public HoverCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Hover();
        }
    }
}