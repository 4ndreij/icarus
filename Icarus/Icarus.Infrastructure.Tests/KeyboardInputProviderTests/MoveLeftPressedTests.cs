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

namespace Icarus.Infrastructure.Tests.KeyboardInputProviderTests
{
    [TestFixture]
    public class MoveLeftPressedTests : BaseKeyboardTests
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void WhenLeftArrowKeyPressed_ShouldFireOnMoveBackward()
        {
            // arrange
            var wasCalled = false;
            keyboardInputProvider.OnMoveLeft += (o, e) => wasCalled = true;
            bool isSysKey = false;
            var keyArgs = new RawKeyEventArgs(KeyCodesHelper.LeftArrow, isSysKey, "Left");
            keyArgs.Key = Key.Left;

            // act
            keyboardListenerMock.Raise(
                x => x.KeyDown += null, keyArgs);

            // assert
            Assert.IsTrue(wasCalled);
        }
    }
}
