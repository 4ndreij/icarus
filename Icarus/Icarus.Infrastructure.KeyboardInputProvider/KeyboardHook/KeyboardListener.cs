using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Icarus.Infrastructure.KeyboardInputProvider.KeyboardHook
{
    /// <summary>
    /// Listens keyboard globally.
    /// Courtesy of Ciantic: https://gist.github.com/Ciantic/471698
    /// Modified by Pris@2105
    /// <remarks>Uses WH_KEYBOARD_LL.</remarks>
    /// </summary>
    public class KeyboardListener : IDisposable
    {
        /// <summary>
        /// Creates global keyboard listener.
        /// </summary>
        public KeyboardListener()
        {
            // We have to store the LowLevelKeyboardProc, so that it is not garbage collected runtime
            hookedLowLevelKeyboardProc = (InterceptKeys.LowLevelKeyboardProc)LowLevelKeyboardProc;

            // Set the hook
            hookId = InterceptKeys.SetHook(hookedLowLevelKeyboardProc);

            // Assign the asynchronous callback event
            hookedKeyboardCallbackAsync = new KeyboardCallbackAsync(KeyboardListener_KeyboardCallbackAsync);
        }

        /// <summary>
        /// Destroys global keyboard listener.
        /// </summary>
        ~KeyboardListener()
        {
            Dispose();
        }

        /// <summary>
        /// Fired when any of the keys is pressed down.
        /// </summary>
        public virtual event RawKeyEventHandler KeyDown;

        /// <summary>
        /// Fired when any of the keys is released.
        /// </summary>
        public virtual event RawKeyEventHandler KeyUp;

        #region Inner workings

        /// <summary>
        /// Hook ID
        /// </summary>
        private IntPtr hookId = IntPtr.Zero;

        /// <summary>
        /// Asynchronous callback hook.
        /// </summary>
        /// <param name="character">Character</param>
        /// <param name="keyEvent">Keyboard event</param>
        /// <param name="vkCode">VKCode</param>
        private delegate void KeyboardCallbackAsync(KeyEvent keyEvent, int vkCode, string character);

        /// <summary>
        /// Actual callback hook.
        /// 
        /// <remarks>Calls asynchronously the asyncCallback.</remarks>
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private IntPtr LowLevelKeyboardProc(int nCode, UIntPtr wParam, IntPtr lParam)
        {
            string chars = "";

            if (nCode >= 0)
                if (wParam.ToUInt32() == (int)KeyEvent.WM_KEYDOWN ||
                    wParam.ToUInt32() == (int)KeyEvent.WM_KEYUP ||
                    wParam.ToUInt32() == (int)KeyEvent.WM_SYSKEYDOWN ||
                    wParam.ToUInt32() == (int)KeyEvent.WM_SYSKEYUP)
                {
                    // Captures the character(s) pressed only on WM_KEYDOWN
                    chars = InterceptKeys.VKCodeToString((uint)Marshal.ReadInt32(lParam),
                        (wParam.ToUInt32() == (int)KeyEvent.WM_KEYDOWN ||
                        wParam.ToUInt32() == (int)KeyEvent.WM_SYSKEYDOWN));

                    hookedKeyboardCallbackAsync.BeginInvoke((KeyEvent)wParam.ToUInt32(), Marshal.ReadInt32(lParam), chars, null, null);
                }

            return InterceptKeys.CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        /// <summary>
        /// Event to be invoked asynchronously (BeginInvoke) each time key is pressed.
        /// </summary>
        private KeyboardCallbackAsync hookedKeyboardCallbackAsync;

        /// <summary>
        /// Contains the hooked callback in runtime.
        /// </summary>
        private InterceptKeys.LowLevelKeyboardProc hookedLowLevelKeyboardProc;

        /// <summary>
        /// HookCallbackAsync procedure that calls accordingly the KeyDown or KeyUp events.
        /// </summary>
        /// <param name="keyEvent">Keyboard event</param>
        /// <param name="vkCode">VKCode</param>
        /// <param name="character">Character as string.</param>
        void KeyboardListener_KeyboardCallbackAsync(KeyEvent keyEvent, int vkCode, string character)
        {
            switch (keyEvent)
            {
                // KeyDown events
                case KeyEvent.WM_KEYDOWN:
                    if (KeyDown != null)
                        {
                            //dispatcher.BeginInvoke(new RawKeyEventHandler(KeyDown), this, new RawKeyEventArgs(vkCode, true, character));
                            KeyDown(this, new RawKeyEventArgs(vkCode, false, character));
                        }
                    break;
                case KeyEvent.WM_SYSKEYDOWN:
                    if (KeyDown != null)
                    {
                        //dispatcher.BeginInvoke(new RawKeyEventHandler(KeyDown), this, new RawKeyEventArgs(vkCode, true, character));
                        KeyDown(this, new RawKeyEventArgs(vkCode, true, character));
                    }
                    break;

                // KeyUp events
                case KeyEvent.WM_KEYUP:
                    if (KeyUp != null)
                    {
                        //dispatcher.BeginInvoke(new RawKeyEventHandler(KeyUp), this, new RawKeyEventArgs(vkCode, false, character));
                        KeyUp(this, new RawKeyEventArgs(vkCode, false, character));
                    }
                    break;
                case KeyEvent.WM_SYSKEYUP:
                    if (KeyUp != null)
                    {
                        //dispatcher.BeginInvoke(new RawKeyEventHandler(KeyUp), this, new RawKeyEventArgs(vkCode, true, character));
                        KeyUp(this, new RawKeyEventArgs(vkCode, true, character));
                    }
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Disposes the hook.
        /// <remarks>This call is required as it calls the UnhookWindowsHookEx.</remarks>
        /// </summary>
        public void Dispose()
        {
            InterceptKeys.UnhookWindowsHookEx(hookId);
        }

        #endregion
    }

    /// <summary>
    /// Raw keyevent handler.
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="args">raw keyevent arguments</param>
    public delegate void RawKeyEventHandler(object sender, RawKeyEventArgs args);
}
