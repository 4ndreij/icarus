using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icarus.Infrastructure.KeyboardInputProvider;
using Icarus.Infrastructure.KeyboardInputProvider.KeyboardHook;
using Moq;
using System.Windows.Input;

namespace Icarus.Infrastructure.Tests
{
    [TestFixture]
    public class MoveDownTests
    {
        KeyboardInputProvider.KeyboardInputProvider keyboardInputProvider;
        Mock<KeyboardListener> keyboardListenerMock;

        [SetUp]
        public void Setup()
        {
            keyboardListenerMock = new Mock<KeyboardListener>();
            keyboardInputProvider = new KeyboardInputProvider.KeyboardInputProvider(keyboardListenerMock.Object);
        }

        [Test]
        public void WhenDownArrowKeyDown_ShouldFireOnMoveDown()
        {
            // arrange
            var wasCalled = false;
            keyboardInputProvider.OnMoveBackward += (o, e) => wasCalled = true;
            bool isSysKey = false;
            var keyArgs = new RawKeyEventArgs(KeyCodesHelper.DownArrow, isSysKey, "Down");
            keyArgs.Key = Key.Down;

            // act
            keyboardListenerMock.Raise(
                x => x.KeyDown += null, keyArgs);

            // assert
            Assert.IsTrue(wasCalled);
        }
    }
}
