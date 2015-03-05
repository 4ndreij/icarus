﻿using AR.Drone.Client.Command;
using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class MoveUpCommandTests : BaseCommandTests
    {
        private MoveUpCommand moveUpCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HoverCommand_ShouldExecuteClientMoveUp()
        {
            // arrange
            moveUpCommand = new MoveUpCommand(DroneClientMock.Object);

            // act
            moveUpCommand.Execute();

            // assert
            DroneClientMock.Verify(x => x.
                Progress(FlightMode.Progressive,
                0,
                0,
                0,
                0.25f)
                , Times.Once);
        }
    }
}