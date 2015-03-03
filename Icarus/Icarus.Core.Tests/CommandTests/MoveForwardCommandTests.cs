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
        public void HoverCommand_ShouldExecuteClientMoveForward()
        {
            // arrange
            moveForwardCommand = new MoveForwardCommand(DroneClientMock.Object);

            // act
            moveForwardCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.MoveForward(), Times.Once);
        }
    }
}