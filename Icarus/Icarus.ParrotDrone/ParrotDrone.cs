using AR.Drone.Client;
using AR.Drone.Client.Command;
using AR.Drone.Client.Configuration;
using AR.Drone.Client.Enums;
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
        Settings settings;

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

        public bool IsConnected
        {
            get
            {
                return droneClient.IsConnected;
            }
        }

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

            var sendConfigTask = new Task(() =>
            {
                if (settings == null)
                    settings = new Settings();

                if (string.IsNullOrEmpty(settings.Custom.SessionId) ||
                    settings.Custom.SessionId == "00000000")
                {
                    // set new session, application and profile
                    droneClient.AckControlAndWaitForConfirmation(); // wait for the control confirmation

                    settings.Custom.SessionId = Settings.NewId();
                    droneClient.Send(settings);

                    droneClient.AckControlAndWaitForConfirmation();

                    settings.Custom.ProfileId = Settings.NewId();
                    droneClient.Send(settings);

                    droneClient.AckControlAndWaitForConfirmation();

                    settings.Custom.ApplicationId = Settings.NewId();
                    droneClient.Send(settings);

                    droneClient.AckControlAndWaitForConfirmation();
                }

                settings.General.NavdataDemo = false;
                settings.General.NavdataOptions = NavdataOptions.All;

                //settings.Video.BitrateCtrlMode = VideoBitrateControlMode.Dynamic;
                settings.Video.Bitrate = 1000;
                settings.Video.MaxBitrate = 2000;

                settings.Leds.LedAnimation = new LedAnimation(LedAnimationType.BlinkGreenRed, 2.0f, 2);
                settings.Control.FlightAnimation = new FlightAnimation(FlightAnimationType.Wave);


                 //start
                settings.Userbox.Command = new UserboxCommand(UserboxCommandType.Start);
                 //stop
                settings.Userbox.Command = new UserboxCommand(UserboxCommandType.Stop);

                //send all changes in one pice
                droneClient.Send(settings);

                droneClient.FlatTrim(); // calibrates the drone on flat surface
            });
            sendConfigTask.Start();
        }

        public void Start()
        {
            droneClient.Start();
            droneClient.Takeoff();
        }

        public void Stop()
        {
            droneClient.Land();
            droneClient.Stop();
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
