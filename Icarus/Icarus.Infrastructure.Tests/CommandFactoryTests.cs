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
        Mock<IDrone> droneClientMock;

        [SetUp]
        public void Setup()
        {
            droneClientMock = new Mock<IDrone>();
            commandFactory = new CommandFactory.CommandFactory(droneClientMock.Object);
        }

        [Test]
        public void WhenRequiredMoveUp_ShouldReturnMoveUpCommand()
        {
            // arrange
            var commandType = CommandType.MoveUp;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<MoveUpCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveDown_ShouldReturnMoveDownCommand()
        { 
            // arrange
            var commandType = CommandType.MoveDown;
            
            // act
            var actualCommand = commandFactory.CreateCommand(commandType);
            
            // assert
            Assert.IsInstanceOf<MoveDownCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveLeft_ShouldReturnMoveLeftCommand()
        { 
            // arrange
            var commandType = CommandType.MoveLeft;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<MoveLeftCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveRight_ShouldReturnMoveRightCommand()
        { 
            // arrange
            var commandType = CommandType.MoveRight;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<MoveRightCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveForward_ShouldReturnMoveForwardCommand()
        { 
            // arrange
            var commandType = CommandType.MoveForward;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<MoveForwardCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredMoveBackward_ShouldReturnMoveBackwardCommand()
        { 
            // arrange
            var commandType = CommandType.MoveBackward;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<MoveBackwardCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredStart_ShouldReturnStartCommand()
        { 
            // arrange
            var commandType = CommandType.Start;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<StartCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredStop_ShouldReturnStopCommand()
        { 
            // arrange
            var commandType = CommandType.Stop;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<StopCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredHover_ShouldReturnHoverCommand()
        {
            // arrange
            var commandType = CommandType.Hover;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<HoverCommand>(actualCommand);
        }

        [Test]
        public void WhenRequiredConfigureCommand_ShouldReturnConfigureCommand()
        { 
            // arrange
            var commandType = CommandType.Configure;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);

            // assert
            Assert.IsInstanceOf<ConfigureCommand>(actualCommand);
        }

        [Test]
        [ExpectedException(ExpectedException=typeof(ArgumentException))]
        public void WhenInvalidCommandType_ShouldThrowArgumentException()
        { 
            // arrange
            var commandType = CommandType.Undefined;

            // act
            var actualCommand = commandFactory.CreateCommand(commandType);
        }
    }
}
