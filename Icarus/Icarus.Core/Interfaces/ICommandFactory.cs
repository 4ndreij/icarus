using Icarus.Core.Commands;
using Icarus.Core.Enums;

namespace Icarus.Core.Interfaces
{
    public interface ICommandFactory
    {
        Command CreateCommand(CommandType commandType);
    }
}
