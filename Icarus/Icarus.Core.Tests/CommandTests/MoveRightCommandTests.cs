using AR.Drone.Client.Command;
using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class MoveRightCommandTests : BaseCommandTests
    {
        private MoveRightCommand moveRightCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HoverCommand_ShouldExecuteClientMoveRight()
        {
            // arrange
            moveRightCommand = new MoveRightCommand(DroneClientMock.Object);

            // act
            moveRightCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.
                Progress(
                FlightMode.Progressive, 
                0,
                0,
                -0.25f,
                0)
                , Times.Once);
        }
    }
}