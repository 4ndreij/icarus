using Icarus.Core.Commands;
using Icarus.Core.Enums;
using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Infrastructure.CommandFactory
{
    public class CommandFactory : ICommandFactory
    {
        IDroneClient droneClient;

        public CommandFactory(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }
        
        public Command CreateCommand(CommandType commandType)
        {
            Command command = null;
            switch (commandType)
            {
                case CommandType.Start:
                    command = new StartCommand(droneClient);
                    break;
                case CommandType.Stop:
                    command = new StopCommand(droneClient);
                    break;
                case CommandType.Configure:
                    command = new ConfigureCommand(droneClient);
                    break;
                case CommandType.MoveBackward:
                    command = new MoveBackwardCommand(droneClient);
                    break;
                case CommandType.MoveDown:
                    command = new MoveDownCommand(droneClient);
                    break;
                case CommandType.MoveForward:
                    command = new MoveForwardCommand(droneClient);
                    break;
                case CommandType.MoveLeft:
                    command = new MoveLeftCommand(droneClient);
                    break;
                case CommandType.MoveRight:
                    command = new MoveRightCommand(droneClient);
                    break;
                case CommandType.MoveUp:
                    command = new MoveUpCommand(droneClient);
                    break;
                default: 
                    throw new ArgumentException("Invalid command type");
            }
            return command;
        }
    }
}
