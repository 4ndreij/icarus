using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class StopCommandTests : BaseCommandTests
    {
        private StopCommand stopCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HoverCommand_ShouldExecuteClientStop()
        {
            // arrange
            stopCommand = new StopCommand(DroneClientMock.Object);

            // act
            stopCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.Stop(), Times.Once);
        }
    }
}