using System;
using Icarus.Core.EventArguments;

namespace Icarus.Core.Interfaces
{
    public interface IInputProviderAdapter
    {
        event EventHandler<ProcessedCommandArgs> OnCommandProcessed;
    }
}