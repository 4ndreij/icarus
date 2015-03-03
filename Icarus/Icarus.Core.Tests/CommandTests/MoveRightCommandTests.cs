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
            DroneClientMock.Verify(x => x.MoveRight(), Times.Once);
        }
    }
}