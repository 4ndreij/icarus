using Icarus.Core.Commands;
using Icarus.Core.Interfaces;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class ConfigureCommandTests : BaseCommandTests
    {
        private ConfigureCommand configureCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void ConfigureCommand_ShouldExecuteClientConfigure()
        {
            // arrange
            var droneConfiguration = new DroneConfiguration.DroneConfiguration();
            configureCommand = new ConfigureCommand(DroneClientMock.Object);

            // act
            configureCommand.SetConfiguration(droneConfiguration);
            configureCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.Configure(droneConfiguration), Times.Once);
        }
    }
}