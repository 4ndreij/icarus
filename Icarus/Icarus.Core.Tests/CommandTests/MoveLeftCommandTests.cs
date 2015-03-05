using AR.Drone.Client.Command;
using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class MoveLeftCommandTests : BaseCommandTests
    {
        private MoveLeftCommand moveLeftCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HoverCommand_ShouldExecuteClientMoveLeft()
        {
            // arrange
            moveLeftCommand = new MoveLeftCommand(DroneClientMock.Object);

            // act
            moveLeftCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.
                Progress(
                FlightMode.Progressive,
                0,
                0,
                0.25f,
                0)
                , Times.Once);
        }
    }
}