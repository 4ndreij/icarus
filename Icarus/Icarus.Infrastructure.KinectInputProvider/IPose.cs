using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Icarus.Infrastructure.KinectInputProvider
{    
    public enum PoseType
    {
        None=0,
        Up=1,
        Down=2,
        Left=3,
        Right
    }

    public interface IPose
    {
        PoseType Type { get; }
        bool IsActive { get; }
    }

    
}
