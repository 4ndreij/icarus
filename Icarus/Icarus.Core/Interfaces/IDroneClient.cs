namespace Icarus.Core.Interfaces
{
    public interface IDroneClient
    {
        void Start();

        void Stop();

        void Configure(DroneConfiguration.DroneConfiguration droneConfiguration);

        void MoveUp();

        void MoveDown();

        void MoveForward();

        void MoveBackward();

        void MoveLeft();

        void MoveRight();

        void Hover();
    }
}