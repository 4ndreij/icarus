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
    public class MoveUpReleasedTests : BaseKeyboardTests
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void WhenPageUpKeyReleased_ShouldFireOnMoveUpStopped()
        {
            // arrange
            var wasCalled = false;
            keyboardInputProvider.OnMoveUpStopped += (o, e) => wasCalled = true;
            bool isSysKey = false;
            var keyArgs = new RawKeyEventArgs(KeyCodesHelper.PageUp, isSysKey, "PageUp");
            keyArgs.Key = Key.PageUp;

            // act
            keyboardListenerMock.Raise(
                x => x.KeyUp += null, keyArgs);

            // assert
            Assert.IsTrue(wasCalled);
        }
    }
}
