using AR.Drone.Client;
using AR.Drone.Client.Command;
using AR.Drone.Client.Configuration;
using System.Threading.Tasks;
namespace Icarus.Core.Interfaces
{
    public interface IDroneClient
    {
        // TODO: keep only needed public commands
        void Start();

        void Stop();

        void Configure(DroneConfiguration.DroneConfiguration droneConfiguration);

        void MoveUp();

        void MoveDown();

        void MoveForward();

        void MoveBackward();

        void MoveLeft();

        void MoveRight();
        // see above TODO

        NetworkConfiguration NetworkConfiguration
        {
            get;
        }

        Task<Settings> GetConfigurationTask();

        void Send(AtCommand command);

        void Send(Settings settings);

        bool AckControlAndWaitForConfirmation();

        void Emergency();

        void ResetEmergency();

        void Land();

        void Takeoff();

        void FlatTrim();

        void Hover();

        void Progress(FlightMode mode, float roll = 0,
            float pitch = 0, float yaw = 0, float gaz = 0);

        void ProgressWithMagneto(FlightMode mode, float roll = 0, float pitch = 0, 
            float yaw = 0, float gaz = 0, float psi = 0, float accuracy = 0);


    }
}