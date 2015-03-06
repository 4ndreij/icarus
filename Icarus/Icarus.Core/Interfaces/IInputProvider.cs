using System;

namespace Icarus.Core.Interfaces
{
    public interface IInputProvider : IDynamicLoadable
    {
        event EventHandler OnStart;

        event EventHandler OnStop;

        event EventHandler OnMoveLeft;

        event EventHandler OnMoveLeftStopped;

        event EventHandler OnMoveRight;

        event EventHandler OnMoveRightStopped;

        event EventHandler OnMoveForward;

        event EventHandler OnMoveForwardStopped;

        event EventHandler OnMoveBackward;

        event EventHandler OnMoveBackwardStopped;

        event EventHandler OnMoveUp;

        event EventHandler OnMoveUpStopped;

        event EventHandler OnMoveDown;

        event EventHandler OnMoveDownStopped;

        event EventHandler OnHover;

        event EventHandler OnHoverStopped;
    }
}