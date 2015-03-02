using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public class MoveBackward : Command
    {
        IDroneClient droneClient;

        public MoveBackward(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveBackward();
        }
    }
}
