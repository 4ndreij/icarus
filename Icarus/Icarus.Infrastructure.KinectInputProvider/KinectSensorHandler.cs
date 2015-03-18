using Microsoft.Kinect;
using System;
using System.Timers;

namespace Icarus.Infrastructure.KinectInputProvider
{
    public class KinectSensorHandler : IKinectSensorHandler
    {
        private bool _isRunning;
        private KinectSensor _sensor;

        private bool _switch;

        // TODO remove this
        private Timer _timer;

        public KinectSensorHandler()
        {
            _sensor = KinectSensor.GetDefault();
            _isRunning = false;
            if (_sensor == null)
                throw new NullReferenceException("Null reference for Kinect sensor");

            SetDummyActions();
        }

        public event EventHandler KinectConnected;

        public event EventHandler KinectDisconnected;

        public event EventHandler<IPose> PoseChanged;

        public bool IsSensorRunning
        {
            get { return _sensor != null && _sensor.IsAvailable && _sensor.IsOpen; }
        }

        /// <summary>
        /// Activates the Kinect sensor
        /// </summary>
        /// <returns>Returns true is Kinect sensor is available and started. False otherwise.</returns>
        public bool StartSensor()
        {         
            _sensor.Open();

            if (!_sensor.IsAvailable)
                return false;

            _sensor.IsAvailableChanged += _sensor_IsAvailableChanged;

            return true;
        }

        public void StopSensor()
        {
            _timer.Stop();
            _sensor.Close();
        }

        private void _sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            if (_isRunning && !e.IsAvailable)
            {
                _isRunning = false;
                OnKinectDisconnected();
            }
            else if (!_isRunning && e.IsAvailable)
            {
                _isRunning = true;
                OnKinectConnected();
            }
        }

        private void OnKinectConnected()
        {
            if (KinectConnected != null)
                KinectConnected(this, EventArgs.Empty);
        }

        private void OnKinectDisconnected()
        {
            if (KinectDisconnected != null)
                KinectDisconnected(this, EventArgs.Empty);
        }

        private void OnPoseChanged(object sender, ElapsedEventArgs e)
        {
            if (PoseChanged != null)
                PoseChanged(this, new UpPose { IsActive = _switch });
            _switch = !_switch;
        }

        private void SetDummyActions()
        {
            _timer = new Timer();            
            _timer.Interval = 2000;
            _timer.Start();
            _timer.Elapsed += OnPoseChanged;
            _switch = false;
        }
    }
}