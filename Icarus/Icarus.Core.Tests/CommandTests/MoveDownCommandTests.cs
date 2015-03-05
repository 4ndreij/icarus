using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class MoveDownCommandTests : BaseCommandTests
    {
        private MoveDownCommand moveDownCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HoverCommand_ShouldExecuteClientMoveDown()
        {
            // arrange
            moveDownCommand = new MoveDownCommand(DroneClientMock.Object);

            // act
            moveDownCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.MoveDown(), Times.Once);
        }
    }
}