using Icarus.Core.Commands;
using Icarus.Core.Interfaces;

namespace Icarus.Infrastructure.Communication
{
    public class CommandInvoker : ICommunicator
    {
        public void ExecuteCommand(Command command)
        {
            command.Execute();
        }
    }
}
