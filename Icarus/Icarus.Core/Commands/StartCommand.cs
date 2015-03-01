using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public class StartCommand : Command
    {
        IDroneClient droneClient;

        public StartCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.Start();
        }
    }
}
