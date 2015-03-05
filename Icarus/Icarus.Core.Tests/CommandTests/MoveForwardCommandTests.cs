using AR.Drone.Client.Command;
using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class MoveForwardCommandTests : BaseCommandTests
    {
        private MoveForwardCommand moveForwardCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void MoveForwardCommand_ShouldExecuteClientMoveForward()
        {
            // arrange
            moveForwardCommand = new MoveForwardCommand(DroneClientMock.Object);

            // act
            moveForwardCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.
                Progress(
                FlightMode.Progressive, 
                0,
                -0.05f,
                0,
                0)
                , Times.Once);
        }
    }
}