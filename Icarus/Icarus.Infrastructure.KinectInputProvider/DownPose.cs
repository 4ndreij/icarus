using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Icarus.Infrastructure.KinectInputProvider
{
    class UpPose : IPose
    {
        public UpPose()
        {
            Type = PoseType.Up;
        }
        public bool IsActive { get; set; }

        public PoseType Type
        {
            get;
            private set;
        }
    }
}
