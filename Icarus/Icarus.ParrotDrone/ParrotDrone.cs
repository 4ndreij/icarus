using AR.Drone.Client;
using AR.Drone.Client.Command;
using AR.Drone.Client.Configuration;
using Icarus.Core.DroneConfiguration;
using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.ParrotDrone
{
    public class ParrotDrone : IDrone, IDynamicLoadable
    {
        DroneClient droneClient;

        public ParrotDrone()
        {
            droneClient = new DroneClient();
        }

        public ParrotDrone(string hostName)
        {
            droneClient = new DroneClient(hostName);
        }

        public ParrotDrone(DroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        Settings settings;

        public void Configure(DroneConfiguration droneConfiguration)
        {
            Task<Settings> configurationTask = droneClient.GetConfigurationTask();
            configurationTask.ContinueWith(
                delegate(Task<Settings> task)
                {
                    if (task.Exception != null)
                    {
                        Trace.TraceWarning("Get configuration task is faulted with exception: {0}",
                            task.Exception.InnerException.Message);
                        return;
                    }

                    settings = task.Result;
                });
            configurationTask.Start();
        }

        public void Start()
        {
            droneClient.Takeoff();
        }

        public void Stop()
        {
            droneClient.Land();
        }

        public void MoveLeft()
        {
            droneClient.Progress(FlightMode.Progressive, yaw: 0.25f);
        }

        public void MoveRight()
        {
            droneClient.Progress(FlightMode.Progressive, yaw: -0.25f);
        }

        public void MoveUp()
        {
            droneClient.Progress(FlightMode.Progressive, gaz: 0.25f);
        }

        public void MoveDown()
        {
            droneClient.Progress(FlightMode.Progressive, gaz: -0.25f);
        }

        public void MoveForward()
        {
            droneClient.Progress(FlightMode.Progressive, pitch: -0.05f);
        }

        public void MoveBackward()
        {
            droneClient.Progress(FlightMode.Progressive, pitch: 0.05f);
        }

        public void Hover()
        {
            droneClient.Hover();
        }
    }
}
