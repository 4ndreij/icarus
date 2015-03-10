using System;
using Icarus.Core.EventArguments;

namespace Icarus.Core.Interfaces
{
    public interface IInputProviderAdapter
    {
        event EventHandler<ProcessedCommandArgs> OnCommandProcessed;
        void SubscribeInputProvider(IInputProvider newInputProvider);
        void ReplaceCommandFactory(ICommandFactory commandFactory);
    }
}