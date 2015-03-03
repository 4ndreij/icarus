using Icarus.Core.Interfaces;
using System.Net;
using System.Net.Sockets;

namespace Icarus.Core.DroneClients
{
    public class WifiClient : IDroneClient
    {
        DroneConfiguration.DroneConfiguration droneConfiguration;
        string droneIpAddress;
        bool isReady;

        public WifiClient()
        {
            isReady = false;
        }

        public void Start()
        { 
            using (var udpClient = GetUdpClient()) // TODO: the user connects the client device to the drone's ESSID network
            {
                // TODO: the client device requests an IP address from the drone DHCP server
                droneIpAddress = "retrieved IP";
            }
        }

        public void Stop()
        {
        }

        public void Configure(DroneConfiguration.DroneConfiguration droneConfiguration)
        {
            this.droneConfiguration = droneConfiguration;

            using(var udpClient = GetUdpClient())
            {
                // TODO: send configure command
            }

            using (var tcpClient = new TcpClient(
                droneConfiguration.HostAddress, 
                droneConfiguration.ConfigurationControlPort))
            {
                // TODO: receive configuration acknowledge
            }
        }

        public void MoveUp()
        {
            using(var udpClient = GetUdpClient())
            {

            }
        }

        public void MoveDown()
        {
            using (var udpClient = GetUdpClient())
            {

            }
        }

        public void MoveForward()
        {
            using (var udpClient = GetUdpClient())
            {

            }
        }

        public void MoveBackward()
        {
            using (var udpClient = GetUdpClient())
            {

            }
        }

        public void MoveLeft()
        {
            using (var udpClient = GetUdpClient())
            {

            }
        }

        public void MoveRight()
        {
            using (var udpClient = GetUdpClient())
            {

            }
        }

        public void Hover()
        {
            using (var udpClient = GetUdpClient())
            {

            }
        }

        UdpClient GetUdpClient()
        {
            var udpClient = new UdpClient(droneConfiguration.MovementCommandPort);
            udpClient.Connect(
                IPAddress.Parse(droneIpAddress), 
                droneConfiguration.MovementCommandPort);
            return udpClient;
        }
    }
}