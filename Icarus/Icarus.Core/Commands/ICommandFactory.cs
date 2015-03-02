using Icarus.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public interface ICommandFactory
    {
        Command CreateCommand(CommandType commandType);
    }
}
