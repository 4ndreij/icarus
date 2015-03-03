using Icarus.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.UI
{
    public class WindowMessages
    {
        IDictionary<CommandType, string> messages;

        public WindowMessages()
        {
            messages = new Dictionary<CommandType, string>();
            messages.Add(CommandType.MoveUp, "Move Up");
            messages.Add(CommandType.MoveDown, "Move Down");
            messages.Add(CommandType.MoveLeft, "Move Left");
            messages.Add(CommandType.MoveRight, "Move Right");
            messages.Add(CommandType.MoveForward, "Move Forward");
            messages.Add(CommandType.MoveBackward, "Move Backward");
        }

        public string GetMessage(CommandType commandType)
        {
            if (messages.ContainsKey(commandType))
            {
                return messages[commandType];
            }
            throw new ArgumentException("Invalid command type");
        }
    }
}
