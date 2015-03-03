using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Icarus.Infrastructure.KeyboardInputProvider
{
    public class KeyboardInputProvider : IInputProvider, IDisposable
    {
        private KeyboardListener keyListener;

        private IDictionary<Key, EventHandler> keyDownEvents;
        private IDictionary<Key, EventHandler> keyUpEvents;

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

        public KeyboardInputProvider()
        {
            CreateKeyDownEventMapping();
            CreateKeyUpEventMapping();
            keyListener = new KeyboardListener();
            keyListener.KeyDown += keyListener_KeyDown;
            keyListener.KeyUp += keyListener_KeyUp;
        }

        private void CreateKeyUpEventMapping()
        {
            keyUpEvents = new Dictionary<Key, EventHandler>();
            keyUpEvents.Add(Key.S, OnHover);
            keyUpEvents.Add(Key.T, OnStop);
            keyUpEvents.Add(Key.Left, OnMoveLeftStopped);
            keyUpEvents.Add(Key.Right, OnMoveRightStopped);
            keyUpEvents.Add(Key.Up, OnMoveForwardStopped);
            keyUpEvents.Add(Key.Down, OnMoveBackwardStopped);
            keyUpEvents.Add(Key.PageDown, OnMoveDownStopped);
            keyUpEvents.Add(Key.PageUp, OnMoveUpStopped);
            keyUpEvents.Add(Key.H, OnHoverStopped);
        }

        private void CreateKeyDownEventMapping()
        {
            keyDownEvents = new Dictionary<Key, EventHandler>();
            keyDownEvents.Add(Key.S, OnStart);
            keyDownEvents.Add(Key.T, null);
            keyDownEvents.Add(Key.Left, OnMoveLeft);
            keyDownEvents.Add(Key.Right, OnMoveRight);
            keyDownEvents.Add(Key.Up, OnMoveForward);
            keyDownEvents.Add(Key.Down, OnMoveBackward);
            keyDownEvents.Add(Key.PageDown, OnMoveDown);
            keyDownEvents.Add(Key.PageUp, OnMoveUp);
            keyDownEvents.Add(Key.H, OnHover);
        }

        void keyListener_KeyUp(object sender, RawKeyEventArgs args)
        {
            if (!args.IsSysKey && keyUpEvents.ContainsKey((Key)args.VKCode) && keyUpEvents[(Key)args.VKCode] != null)
            {
                keyUpEvents[(Key)args.VKCode](sender, args);
            }
        }

        void keyListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            if (!args.IsSysKey && keyDownEvents.ContainsKey((Key)args.VKCode) && keyDownEvents[(Key)args.VKCode] != null)
            {
                keyDownEvents[(Key)args.VKCode](sender, args);
            }
        }

        public void Dispose()
        {
            keyListener.Dispose();
        }

        ~KeyboardInputProvider()
        {
            Dispose();
        }
    }
}

