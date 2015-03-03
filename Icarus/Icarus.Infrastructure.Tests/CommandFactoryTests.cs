using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icarus.Infrastructure.CommandFactory;
using Icarus.Core.Enums;
using NUnit.Framework;
using Icarus.Core.Commands;
using Moq;
using Icarus.Core.Interfaces;

namespace Icarus.Infrastructure.Tests
{
    [TestFixture]
    public class CommandFactoryTests
    {
        CommandFactory.CommandFactory commandFactory;
        Mock<IDroneClient> droneClientMock;

        [TestFixtureSetUp]
        public void Setup()
        {
            droneClientMock = new Mock<IDroneClient>();
            commandFactory = new CommandFactory.CommandFactory(droneClientMock.Object);

        }

        [Test]
        public void WhenRequiredMoveUp_ShouldReturnMoveUpCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.MoveUp);
            Assert.IsInstanceOf<MoveUpCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveDown_ShouldReturnMoveDownCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.MoveDown);
            Assert.IsInstanceOf<MoveDownCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveLeft_ShouldReturnMoveLeftCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.MoveLeft);
            Assert.IsInstanceOf<MoveLeftCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveRight_ShouldReturnMoveRightCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.MoveRight);
            Assert.IsInstanceOf<MoveRightCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveForward_ShouldReturnMoveForwardCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.MoveForward);
            Assert.IsInstanceOf<MoveForwardCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveBackward_ShouldReturnMoveBackwardCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.MoveBackward);
            Assert.IsInstanceOf<MoveBackwardCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredStart_ShouldReturnStartCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.Start);
            Assert.IsInstanceOf<StartCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredStop_ShouldReturnStopCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.Stop);
            Assert.IsInstanceOf<StopCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredHover_ShouldReturnHoverCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.Hover);
            Assert.IsInstanceOf<HoverCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredConfigureCommand_ShouldReturnConfigureCommand()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.Configure);
            Assert.IsInstanceOf<ConfigureCommand>(actualCommand);
        }

        [Test]
        [ExpectedException(ExpectedException=typeof(ArgumentException))]
        public void WhenInvalidCommandType_ShouldThrowArgumentException()
        {
            var actualCommand = commandFactory.CreateCommand(CommandType.Undefined);
        }
    }
}
