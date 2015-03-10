using Icarus.Infrastructure.KeyboardInputProvider.KeyboardHook;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Infrastructure.Tests.KeyboardInputProviderTests
{
    public class BaseKeyboardTests : IDisposable
    {
        protected KeyboardInputProvider.KeyboardInputProvider keyboardInputProvider;
        protected Mock<KeyboardListener> keyboardListenerMock;

        public virtual void Setup()
        {
            keyboardListenerMock = new Mock<KeyboardListener>();
            keyboardInputProvider = new KeyboardInputProvider.KeyboardInputProvider(keyboardListenerMock.Object);
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        private Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //TODO: Managed cleanup code here, while managed refs still valid
            }
            keyboardInputProvider.Dispose();

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate 
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// The destructor for the class.
        /// </summary>
        ~BaseKeyboardTests() 
        { 
            this.Dispose(false); 
        }

        #endregion
    }
}
