using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Infrastructure.KeyboardInputProvider
{
    public class RawKeyEventArgs : EventArgs
    {
        /// <summary>
        /// VKCode of the key.
        /// </summary>
        public int VKCode;

        /// <summary>
        /// WPF Key of the key.
        /// </summary>
        //public Key Key;

        /// <summary>
        /// Is the hitted key system key.
        /// </summary>
        public bool IsSysKey;

        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>Returns string representation of this key, if not possible empty string is returned.</returns>
        public override string ToString()
        {
            return Character;
        }

        /// <summary>
        /// Unicode character of key pressed.
        /// </summary>
        public string Character;

        /// <summary>
        /// Create raw keyevent arguments.
        /// </summary>
        /// <param name="VKCode"></param>
        /// <param name="isSysKey"></param>
        /// <param name="Character">Character</param>
        public RawKeyEventArgs(int VKCode, bool isSysKey, string Character)
        {
            this.VKCode = VKCode;
            this.IsSysKey = isSysKey;
            this.Character = Character;
            //this.Key = System.Windows.Input.KeyInterop.KeyFromVirtualKey(VKCode);
        }
    }
}
