using Icarus.Core.Interfaces;
using Icarus.Infrastructure.KinectInputProvider;
using log4net;
using System;
using System.Collections.Generic;

namespace Icarus.Infrastructure.KeyboardInputProvider
{
    public class KinectInputProvider : IInputProvider, IDisposable
    {
        private Dictionary<PoseType, Action<IPose>> _activePosesActionList;        

        public KinectSensorHandler _sensorHandler;
       
        public KinectInputProvider()
        {                 
            _sensorHandler = new KinectSensorHandler();

            if (!_sensorHandler.StartSensor())
                return;

            _activePosesActionList = new Dictionary<PoseType, Action<IPose>>();
            _activePosesActionList.Add(PoseType.Up, MoveUp);
            _activePosesActionList.Add(PoseType.Down, MoveDown);
            _activePosesActionList.Add(PoseType.Left, MoveLeft);
            _activePosesActionList.Add(PoseType.Right, MoveRight);

            _sensorHandler.KinectConnected += sensorHandler_KinectConnected;
            _sensorHandler.KinectDisconnected += sensorHandler_KinectDisconnected;
            _sensorHandler.PoseChanged += sensorHandler_PoseChanged;
        }

        public event EventHandler OnHover;

        public event EventHandler OnHoverStopped;

        public event EventHandler OnMoveBackward;

        public event EventHandler OnMoveBackwardStopped;

        public event EventHandler OnMoveDown;

        public event EventHandler OnMoveDownStopped;

        public event EventHandler OnMoveForward;

        public event EventHandler OnMoveForwardStopped;

        public event EventHandler OnMoveLeft;

        public event EventHandler OnMoveLeftStopped;

        public event EventHandler OnMoveRight;

        public event EventHandler OnMoveRightStopped;

        public event EventHandler OnMoveUp;

        public event EventHandler OnMoveUpStopped;

        public event EventHandler OnStart;

        public event EventHandler OnStop;

        public void Dispose()
        {
            _sensorHandler.StopSensor();
        }

        private void MoveDown(IPose pose)
        {
            if (pose.IsActive)
            {
                if (OnMoveDown != null)
                    OnMoveDown(this, EventArgs.Empty);
            }
            else
            {
                if (OnMoveDownStopped != null)
                    OnMoveDownStopped(this, EventArgs.Empty);
            }
        }

        private void MoveLeft(IPose pose)
        {
            if (pose.IsActive)
            {
                if (OnMoveLeft != null)
                    OnMoveLeft(this, EventArgs.Empty);
            }
            else
            {
                if (OnMoveLeftStopped != null)
                    OnMoveLeftStopped(this, EventArgs.Empty);
            }
        }

        private void MoveRight(IPose pose)
        {
            if (pose.IsActive)
            {
                if (OnMoveRight != null)
                    OnMoveRight(this, EventArgs.Empty);
            }
            else
            {
                if (OnMoveRightStopped != null)
                    OnMoveRightStopped(this, EventArgs.Empty);
            }
        }
        private void MoveUp(IPose pose)
        {
            if (pose.IsActive)
            {
                if (OnMoveUp != null)
                    OnMoveUp(this, EventArgs.Empty);
            }
            else
            {
                if (OnMoveUpStopped != null)
                    OnMoveUpStopped(this, EventArgs.Empty);
            }
        }

        private void sensorHandler_KinectConnected(object sender, EventArgs e)
        {
            //_logger.Info("Kinect connected");
        }

        private void sensorHandler_KinectDisconnected(object sender, EventArgs e)
        {
            //_logger.Info("Kinect disconnected");
        }

        private void sensorHandler_PoseChanged(object sender, IPose e)
        {
            if (_activePosesActionList.ContainsKey(e.Type))
                _activePosesActionList[e.Type](e);
        }
    }
}