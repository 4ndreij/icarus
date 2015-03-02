using Icarus.Core.Commands;
using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
