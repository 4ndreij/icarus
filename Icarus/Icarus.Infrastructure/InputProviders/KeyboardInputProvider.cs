using System;
using Icarus.Core.Interfaces;

namespace Icarus.Infrastructure.InputProviders
{
    public class KeyboardInputProvider : IInputProvider
    {
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
    }
}