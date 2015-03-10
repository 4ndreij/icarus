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
    public class HoverReleasedTests : BaseKeyboardTests
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void WhenHoverKeyReleased_ShouldFireOnHoverStopped()
        {
            // arrange
            var wasCalled = false;
            keyboardInputProvider.OnHoverStopped += (o, e) => wasCalled = true;
            bool isSysKey = false;
            var keyArgs = new RawKeyEventArgs(KeyCodesHelper.HKey, isSysKey, "Hover");
            keyArgs.Key = Key.H;

            // act
            keyboardListenerMock.Raise(
                x => x.KeyUp += null, keyArgs);

            // assert
            Assert.IsTrue(wasCalled);
        }
    }
}
