using AR.Drone.Client.Enums;
namespace AR.Drone.Client.Command
{
    public class CalibrateCommand : AtCommand
    {
        private readonly Device device;

        private CalibrateCommand(Device device)
        {
            this.device = device;
        }

        protected override string ToAt(int sequenceNumber)
        {
            return string.Format("AT*CALIB={0},{1}\r", sequenceNumber, (int) device);
        }
    }
}