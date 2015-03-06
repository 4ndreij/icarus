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

namespace Icarus.DroneClients
{
    public class WifiDroneClient : DroneClient, IDroneClient
    {
        Settings settings;

        public void Configure(DroneConfiguration droneConfiguration)
        {
            Task<Settings> configurationTask = base.Configure();
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
            base.Takeoff();
        }

        public void Stop()
        {
            base.Land();
        }

        public void MoveLeft()
        {
            base.Progress(FlightMode.Progressive, yaw: 0.25f);
        }

        public void MoveRight()
        {
            base.Progress(FlightMode.Progressive, yaw: -0.25f);
        }

        public void MoveUp()
        {
            base.Progress(FlightMode.Progressive, gaz: 0.25f);
        }

        public void MoveDown()
        {
            base.Progress(FlightMode.Progressive, gaz: -0.25f);
        }

        public void MoveForward()
        {
            base.Progress(FlightMode.Progressive, pitch: -0.05f);
        }

        public void MoveBackward()
        {
            base.Progress(FlightMode.Progressive, pitch: 0.05f);
        }
    }
}
