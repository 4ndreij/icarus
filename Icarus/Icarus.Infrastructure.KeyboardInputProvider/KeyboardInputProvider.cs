using System;
using System.Windows.Input;
using Icarus.Core.Interfaces;
using Icarus.Infrastructure.KeyboardInputProvider.KeyboardHook;

namespace Icarus.Infrastructure.KeyboardInputProvider
{
    public class KeyboardInputProvider : IInputProvider, IDisposable
    {
        private readonly KeyboardListener keyListener;

        public KeyboardInputProvider()
        {
            keyListener = new KeyboardListener();
            keyListener.KeyDown += keyListener_KeyDown;
            keyListener.KeyUp += keyListener_KeyUp;
        }

        public void Dispose()
        {
            keyListener.Dispose();
        }

        public event EventHandler OnStart;

        public event EventHandler OnStop;

        public event EventHandler OnMoveLeft;

        public event EventHandler OnMoveLeftStopped;

        public event EventHandler OnMoveRight;

        public event EventHandler OnMoveRightStopped;

        public event EventHandler OnMoveForward;

        public event EventHandler OnMoveForwardStopped;

        public event EventHandler OnMoveBackward;

        public event EventHandler OnMoveBackwardStopped;

        public event EventHandler OnMoveUp;

        public event EventHandler OnMoveUpStopped;

        public event EventHandler OnMoveDown;

        public event EventHandler OnMoveDownStopped;

        public event EventHandler OnHover;

        public event EventHandler OnHoverStopped;

        private void keyListener_KeyUp(object sender, RawKeyEventArgs args)
        {
            HandleKeyUpevents(sender, args);
        }

        protected virtual void HandleKeyUpevents(object sender, RawKeyEventArgs args)
        {
            switch (args.Key)
            {
                case Key.S:
                    // do nothing
                    break;
                case Key.T:
                    // do nothing
                    break;
                case Key.Left:
                    if (OnMoveLeftStopped != null)
                    {
                        OnMoveLeftStopped(sender, args);
                    }
                    break;
                case Key.Right:
                    if (OnMoveRightStopped != null)
                    {
                        OnMoveRightStopped(sender, args);
                    }
                    break;
                case Key.Up:
                    if (OnMoveForwardStopped != null)
                    {
                        OnMoveForwardStopped(sender, args);
                    }
                    break;
                case Key.Down:
                    if (OnMoveBackwardStopped != null)
                    {
                        OnMoveBackwardStopped(sender, args);
                    }
                    break;
                case Key.PageUp:
                    if (OnMoveUpStopped != null)
                    {
                        OnMoveUpStopped(sender, args);
                    }
                    break;
                case Key.PageDown:
                    if (OnMoveDownStopped != null)
                    {
                        OnMoveDownStopped(sender, args);
                    }
                    break;
                case Key.H:
                    if (OnHoverStopped != null)
                    {
                        OnHoverStopped(sender, args);
                    }
                    break;
            }
        }

        private void keyListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            HandleKeyDownEvents(sender, args);
        }

        protected virtual void HandleKeyDownEvents(object sender, RawKeyEventArgs args)
        {
            switch (args.Key)
            {
                case Key.S:
                    if (OnStart != null)
                    {
                        OnStart(sender, args);
                    }
                    break;
                case Key.T:
                    if (OnStop != null)
                    {
                        OnStop(sender, args);
                    }
                    break;
                case Key.Left:
                    if (OnMoveLeft != null)
                    {
                        OnMoveLeft(sender, args);
                    }
                    break;
                case Key.Right:
                    if (OnMoveRight != null)
                    {
                        OnMoveRight(sender, args);
                    }
                    break;
                case Key.Up:
                    if (OnMoveForward != null)
                    {
                        OnMoveForward(sender, args);
                    }
                    break;
                case Key.Down:
                    if (OnMoveBackward != null)
                    {
                        OnMoveBackward(sender, args);
                    }
                    break;
                case Key.PageUp:
                    if (OnMoveUp != null)
                    {
                        OnMoveUp(sender, args);
                    }
                    break;
                case Key.PageDown:
                    if (OnMoveDown != null)
                    {
                        OnMoveDown(sender, args);
                    }
                    break;
                case Key.H:
                    if (OnHover != null)
                    {
                        OnHover(sender, args);
                    }
                    break;
            }
        }

        ~KeyboardInputProvider()
        {
            Dispose();
        }
    }
}