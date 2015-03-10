using System;
using Icarus.Core.Commands;
using Icarus.Core.Enums;
using Icarus.Core.Interfaces;

namespace Icarus.Infrastructure.CommandFactory
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IDrone drone;

        public CommandFactory(IDrone drone)
        {
            this.drone = drone;
        }

        public Command CreateCommand(CommandType commandType)
        {
            Command command = null;
            switch (commandType)
            {
                case CommandType.Start:
                    command = new StartCommand(drone);
                    break;
                case CommandType.Stop:
                    command = new StopCommand(drone);
                    break;
                case CommandType.Configure:
                    command = new ConfigureCommand(drone);
                    break;
                case CommandType.MoveBackward:
                    command = new MoveBackwardCommand(drone);
                    break;
                case CommandType.MoveDown:
                    command = new MoveDownCommand(drone);
                    break;
                case CommandType.MoveForward:
                    command = new MoveForwardCommand(drone);
                    break;
                case CommandType.MoveLeft:
                    command = new MoveLeftCommand(drone);
                    break;
                case CommandType.MoveRight:
                    command = new MoveRightCommand(drone);
                    break;
                case CommandType.MoveUp:
                    command = new MoveUpCommand(drone);
                    break;
                case CommandType.Hover:
                    command = new HoverCommand(drone);
                    break;
                default:
                    throw new ArgumentException("Invalid command type");
            }
            return command;
        }
    }
}