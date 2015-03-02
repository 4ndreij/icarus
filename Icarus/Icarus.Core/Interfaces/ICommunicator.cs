using Icarus.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Core.Interfaces
{
    public interface ICommunicator
    {
        void ExecuteCommand(Command command);
    }
}
