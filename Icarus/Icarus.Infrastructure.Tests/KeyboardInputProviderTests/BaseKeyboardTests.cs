using Icarus.Infrastructure.KeyboardInputProvider.KeyboardHook;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Infrastructure.Tests.KeyboardInputProviderTests
{
    public class BaseKeyboardTests
    {
        protected KeyboardInputProvider.KeyboardInputProvider keyboardInputProvider;
        protected Mock<KeyboardListener> keyboardListenerMock;

        public virtual void Setup()
        {
            keyboardListenerMock = new Mock<KeyboardListener>();
            keyboardInputProvider = new KeyboardInputProvider.KeyboardInputProvider(keyboardListenerMock.Object);
        }
    }
}
