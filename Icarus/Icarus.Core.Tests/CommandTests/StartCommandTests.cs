using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class StartCommandTests : BaseCommandTests
    {
        private StartCommand startCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HoverCommand_ShouldExecuteClientStart()
        {
            // arrange
            startCommand = new StartCommand(DroneClientMock.Object);

            // act
            startCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.Takeoff(), Times.Once);
        }
    }
}