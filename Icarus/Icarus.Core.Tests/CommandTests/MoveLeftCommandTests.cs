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
            DroneClientMock.Verify(x => x.MoveLeft(), Times.Once);
        }
    }
}