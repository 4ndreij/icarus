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
    public class MoveDownPressedTests : BaseKeyboardTests
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void WhenPageDownKeyPressed_ShouldFireOnMoveDown()
        {
            // arrange
            var wasCalled = false;
            keyboardInputProvider.OnMoveDown += (o, e) => wasCalled = true;
            bool isSysKey = false;
            var keyArgs = new RawKeyEventArgs(KeyCodesHelper.PageDown, isSysKey, "PageDown");
            keyArgs.Key = Key.PageDown;

            // act
            keyboardListenerMock.Raise(
                x => x.KeyDown += null, keyArgs);

            // assert
            Assert.IsTrue(wasCalled);
        }
    }
}
