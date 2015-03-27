﻿namespace Icarus.Infrastructure.KinectInputProvider
{
    class DownPose : IPose
    {
        public DownPose()
        {
            Type = PoseType.Down;
        }
        public bool IsActive { get; set; }

        public PoseType Type
        {
            get;
            private set;
        }
    }
}