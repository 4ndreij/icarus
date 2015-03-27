using Microsoft.Kinect;

//using System.Timers;
using Microsoft.Kinect.VisualGestureBuilder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Icarus.Infrastructure.KinectInputProvider
{
    public class KinectSensorHandler : IKinectSensorHandler
    {
        public KinectSensor _sensor;
        private readonly Dictionary<string, IPose> _gestures;
        private Body[] _bodies;
        private VisualGestureBuilderFrameSource _gestureDetector;
        private VisualGestureBuilderFrameReader _gestureReader;
        private bool _isRunning;

        public KinectSensorHandler()
        {
            _sensor = KinectSensor.GetDefault();
            _isRunning = false;
            if (_sensor == null)
                throw new NullReferenceException("Null reference for Kinect sensor");

            _gestures = new Dictionary<string, IPose>
                {
                    {"Bouncer_v2", new UpPose()},
                    {"Prisoner", new DownPose()},
                    {"HandTemple_v2", new RightPose()},
                    {"FigLeaf", new LeftPose()}
                };
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

            //if (!_sensor.IsAvailable)
            //    return false;

            _sensor.IsAvailableChanged += _sensor_IsAvailableChanged;

            _gestureDetector = new VisualGestureBuilderFrameSource(_sensor, 0);
            if (_gestureDetector != null)
            {
                var db = new VisualGestureBuilderDatabase("MultiGestures.gbd");
                foreach (var gesture in db.AvailableGestures)
                {
                    _gestureDetector.AddGesture(gesture);
                }

                _gestureReader = _gestureDetector.OpenReader();
                _gestureReader.FrameArrived += _gestureReader_FrameArrived;
            }

            var bodyReader = _sensor.BodyFrameSource.OpenReader();
            bodyReader.FrameArrived += bodyReader_FrameArrived;

            return true;
        }

        public void StopSensor()
        {
            //_timer.Stop();
            _gestureReader.FrameArrived -= _gestureReader_FrameArrived;
            _sensor.Close();
        }

        private void _gestureReader_FrameArrived(object sender, VisualGestureBuilderFrameArrivedEventArgs e)
        {
            using (var frame = e.FrameReference.AcquireFrame())
            {
                if (frame == null || frame.DiscreteGestureResults == null)
                    return;

                foreach (var discreteGestureResult in frame.DiscreteGestureResults)
                {
                    var gesture = discreteGestureResult.Key;
                    var result = discreteGestureResult.Value;
                    GestureRefresh(gesture, result);
                }
            }
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

        private void bodyReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            using (var frame = e.FrameReference.AcquireFrame())
            {
                if (frame == null)
                    return;

                if (_bodies == null)
                    _bodies = new Body[frame.BodyCount];

                frame.GetAndRefreshBodyData(_bodies);

                _gestureDetector.TrackingId = _bodies.Any(b => b.IsTracked) ? _bodies.FirstOrDefault(b => b.IsTracked).TrackingId : 0;
            }
        }
        private void GestureRefresh(Gesture gesture, DiscreteGestureResult result)
        {
            if (!_gestures.ContainsKey(gesture.Name))
                return;
            var pose = _gestures[gesture.Name];
            var state = result.Detected && result.Confidence > 0.4;
            if (pose.IsActive == state)
                return;

            pose.IsActive = state;
            OnPoseChanged(pose);
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

        private void OnPoseChanged(IPose pose)
        {
            if (PoseChanged != null)
                PoseChanged(this, pose);
        }
    }
}