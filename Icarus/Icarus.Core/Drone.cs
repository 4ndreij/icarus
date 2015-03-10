using System;
using Icarus.Core.Commands;
using Icarus.Core.Enums;
using Icarus.Core.EventArguments;
using Icarus.Core.Interfaces;
using System.Collections.Generic;

namespace Icarus.Core
{
    public class Drone : IInputProviderAdapter
    {
        private readonly ICommandFactory commandFactory;
        private readonly ICommunicator communicator;
        private readonly IList<IInputProvider> inputProviders;

        public Drone(
           IInputProvider inputProvider,
           ICommandFactory commandFactory,
           ICommunicator communicator)
        {
            this.inputProviders = new List<IInputProvider>() { inputProvider };
            this.commandFactory = commandFactory;
            this.communicator = communicator;
            SubscribeToInputProvidersEvents();
        }

        public Drone(
            IList<IInputProvider> inputProviders,
            ICommandFactory commandFactory,
            ICommunicator communicator)
        {
            this.inputProviders = inputProviders;
            this.commandFactory = commandFactory;
            this.communicator = communicator;
            SubscribeToInputProvidersEvents();
        }

        public event EventHandler<ProcessedCommandArgs> OnCommandProcessed;

        public void SubscribeInputProvider(IInputProvider newInputProvider)
        {
            bool providerAlreadyExists = false;
            foreach (var provider in this.inputProviders)
            {
                if (provider.GetType() == newInputProvider.GetType())
                {
                    providerAlreadyExists = true;
                    break;
                }
            }
            if (!providerAlreadyExists)
            {
                inputProviders.Add(newInputProvider);
                SubscribeToInputProviderEvents(newInputProvider);
            }
        }

        void SubscribeToInputProviderEvents(IInputProvider inputProvider)
        {
            inputProvider.OnStart += inputProvider_OnStart;
            inputProvider.OnStop += inputProvider_OnStop;
            inputProvider.OnMoveBackward += inputProvider_OnMoveBackward;
            inputProvider.OnMoveBackwardStopped += inputProvider_OnHover;
            inputProvider.OnMoveDown += inputProvider_OnMoveDown;
            inputProvider.OnMoveDownStopped += inputProvider_OnHover;
            inputProvider.OnMoveForward += inputProvider_OnMoveForward;
            inputProvider.OnMoveForwardStopped += inputProvider_OnHover;
            inputProvider.OnMoveLeft += inputProvider_OnMoveLeft;
            inputProvider.OnMoveLeftStopped += inputProvider_OnHover;
            inputProvider.OnMoveRight += inputProvider_OnMoveRight;
            inputProvider.OnMoveRightStopped += inputProvider_OnHover;
            inputProvider.OnMoveUp += inputProvider_OnMoveUp;
            inputProvider.OnMoveUpStopped += inputProvider_OnStop;
            inputProvider.OnHover += inputProvider_OnHover;
            inputProvider.OnHoverStopped += inputProvider_OnHover;
        }

        private void SubscribeToInputProvidersEvents()
        {
            foreach (var inputProvider in inputProviders)
            {
                SubscribeToInputProviderEvents(inputProvider);
            }
        }

        private void inputProvider_OnHover(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.Hover);
            communicator.ExecuteCommand(command);
            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.Hover });
            }
        }

        private void inputProvider_OnMoveUp(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveUp);
            communicator.ExecuteCommand(command);
            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.MoveUp });
            }
        }

        private void inputProvider_OnMoveRight(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveRight);
            communicator.ExecuteCommand(command);
            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.MoveRight });
            }
        }

        private void inputProvider_OnMoveLeft(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveLeft);
            communicator.ExecuteCommand(command);
            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.MoveLeft });
            }
        }

        private void inputProvider_OnMoveForward(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveForward);
            communicator.ExecuteCommand(command);
            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.MoveForward });
            }
        }

        private void inputProvider_OnMoveDown(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveDown);
            communicator.ExecuteCommand(command);
            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.MoveDown });
            }
        }

        private void inputProvider_OnMoveBackward(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveBackward);
            communicator.ExecuteCommand(command);
            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.MoveBackward });
            }
        }

        private void inputProvider_OnStop(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.Stop);
            communicator.ExecuteCommand(command);
            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.Stop });
            }
        }

        private void inputProvider_OnStart(object sender, EventArgs e)
        {
            var configureCommand = commandFactory.CreateCommand(CommandType.Configure);
            communicator.ExecuteCommand(configureCommand);

            var command = commandFactory.CreateCommand(CommandType.Start);
            communicator.ExecuteCommand(command);

            if (OnCommandProcessed != null)
            {
                OnCommandProcessed(this, new ProcessedCommandArgs { CommandType = CommandType.Start });
            }
        }
    }
}