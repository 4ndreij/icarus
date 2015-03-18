using System;

namespace Icarus.Infrastructure.KinectInputProvider
{
    internal interface IKinectSensorHandler
    {
        bool IsSensorRunning { get; }

        bool StartSensor();

        void StopSensor();

        event EventHandler KinectDisconnected;

        event EventHandler KinectConnected;

        event EventHandler<IPose> PoseChanged;
    }
}