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