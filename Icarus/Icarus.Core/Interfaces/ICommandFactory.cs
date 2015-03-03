using Icarus.Core.Commands;
using Icarus.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Core.Interfaces
{
    public interface ICommandFactory
    {
        Command CreateCommand(CommandType commandType);
    }
}
