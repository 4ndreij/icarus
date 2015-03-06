﻿using Icarus.Core.Interfaces;

namespace Icarus.Core.Commands
{
    public class MoveForwardCommand : Command
    {
        readonly IDrone droneClient;

        public MoveForwardCommand(IDrone droneClient)
        {
            this.droneClient = droneClient;
        }

        public override void Execute()
        {
            droneClient.MoveForward();
        }
    }
}
