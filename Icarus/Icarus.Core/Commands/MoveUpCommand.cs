using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public class MoveUpCommand : Command
    {
        IDroneClient droneClient;

        public MoveUpCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveUp();
        }
    }
}
