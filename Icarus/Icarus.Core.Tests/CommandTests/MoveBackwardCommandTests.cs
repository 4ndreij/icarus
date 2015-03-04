﻿using AR.Drone.Client.Command;
using Icarus.Core.Commands;
using Moq;
using NUnit.Framework;

namespace Icarus.Core.Tests.CommandTests
{
    [TestFixture]
    public class MoveBackwardCommandTests : BaseCommandTests
    {
        private MoveBackwardCommand moveBackwardCommand;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HoverCommand_ShouldExecuteClientMoveBackward()
        {
            // arrange
            moveBackwardCommand = new MoveBackwardCommand(DroneClientMock.Object);

            // act
            moveBackwardCommand.Execute();

            // assert
            DroneClientMock.Verify(
                x => x
                .Progress(
                FlightMode.Progressive,
                 0,
                 0.05f,
                 0,
                 0), 
                 Times.Once);
        }
    }
}