namespace Icarus.Infrastructure.KinectInputProvider
{
    class LeftPose : IPose
    {
        public LeftPose()
        {
            Type = PoseType.Left;
        }
        public bool IsActive { get; set; }

        public PoseType Type
        {
            get;
            private set;
        }
    }
}