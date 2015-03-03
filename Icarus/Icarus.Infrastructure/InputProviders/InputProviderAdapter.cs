using System;
using Icarus.Core.Enums;
using Icarus.Core.Interfaces;

namespace Icarus.Infrastructure.InputProviders
{
    public class InputProviderAdapter : IInputProviderAdapter
    {
        private readonly ICommandFactory commandFactory;
        private readonly ICommunicator communicator;
        private readonly IInputProvider inputProvider;

        public InputProviderAdapter(IInputProvider inputProvider, ICommandFactory commandFactory, ICommunicator communicator)
        {
            this.inputProvider = inputProvider;
            this.commandFactory = commandFactory;
            this.communicator = communicator;
            SubscribeToInputProviderEvents();
        }

        private void SubscribeToInputProviderEvents()
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

        private void inputProvider_OnHover(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.Hover);
            communicator.ExecuteCommand(command);
        }

        private void inputProvider_OnMoveUp(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveUp);
            communicator.ExecuteCommand(command);
        }

        private void inputProvider_OnMoveRight(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveRight);
            communicator.ExecuteCommand(command);
        }

        private void inputProvider_OnMoveLeft(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveLeft);
            communicator.ExecuteCommand(command);
        }

        private void inputProvider_OnMoveForward(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveForward);
            communicator.ExecuteCommand(command);
        }

        private void inputProvider_OnMoveDown(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveDown);
            communicator.ExecuteCommand(command);
        }

        private void inputProvider_OnMoveBackward(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.MoveBackward);
            communicator.ExecuteCommand(command);
        }

        private void inputProvider_OnStop(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.Stop);
            communicator.ExecuteCommand(command);
        }

        private void inputProvider_OnStart(object sender, EventArgs e)
        {
            var command = commandFactory.CreateCommand(CommandType.Start);
            communicator.ExecuteCommand(command);
        }
    }
}