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
    public class MoveDownReleasedTests : BaseKeyboardTests
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void WhenPageDownKeyReleased_ShouldFireOnMoveDownStopped()
        {
            // arrange
            var wasCalled = false;
            keyboardInputProvider.OnMoveDownStopped += (o, e) => wasCalled = true;
            bool isSysKey = false;
            var keyArgs = new RawKeyEventArgs(KeyCodesHelper.PageDown, isSysKey, "PageDown");
            keyArgs.Key = Key.PageDown;

            // act
            keyboardListenerMock.Raise(
                x => x.KeyUp += null, keyArgs);

            // assert
            Assert.IsTrue(wasCalled);
        }
    }
}
