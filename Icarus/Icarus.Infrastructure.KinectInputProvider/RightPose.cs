namespace Icarus.Infrastructure.KinectInputProvider
{
    class RightPose : IPose
    {
        public RightPose()
        {
            Type = PoseType.Right;
        }
        public bool IsActive { get; set; }

        public PoseType Type
        {
            get;
            private set;
        }
    }
}