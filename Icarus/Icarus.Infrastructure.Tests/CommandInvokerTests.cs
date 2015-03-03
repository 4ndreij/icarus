using Icarus.Core.Commands;
using Icarus.Core.DroneConfiguration;
using Icarus.Core.Interfaces;
using Icarus.Infrastructure.Communication;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Infrastructure.Tests
{
    [TestFixture]
    public class CommandInvokerTests
    {
        CommandInvoker commandInvoker;
        Mock<Command> commandMock;

        [TestFixtureSetUp]
        public void Setup()
        {
            commandInvoker = new CommandInvoker();
        }

        [Test]
        public void WhenPassedCommandInstace_ShouldInvokeItOnce()
        {
            // arrange
            commandMock = new Mock<Command>();

            // act
            commandInvoker.ExecuteCommand(commandMock.Object);

            // assert
            commandMock.Verify(x => x.Execute(), Times.Once());
        }
    }
}
