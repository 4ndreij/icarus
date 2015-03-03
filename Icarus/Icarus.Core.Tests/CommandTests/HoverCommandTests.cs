using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class HoverCommandTests : BaseCommandTests
    {
        private HoverCommand hoverCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HoverCommand_ShouldExecuteClientHover()
        {
            // arrange
            hoverCommand = new HoverCommand(DroneClientMock.Object);

            // act
            hoverCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.Hover(), Times.Once);
        }
    }
}