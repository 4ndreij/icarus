using AR.Drone.Client.Configuration;
using Icarus.Core.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Icarus.Core.Commands
{
    public class ConfigureCommand : Command
    {
        readonly IDroneClient droneClient;
        Settings settings;
        DroneConfiguration.DroneConfiguration droneConfiguration;

        public ConfigureCommand(IDroneClient droneClient)
        {
            this.droneClient = droneClient;
        }

        public void SetConfiguration(DroneConfiguration.DroneConfiguration droneConfiguration)
        {
            this.droneConfiguration = droneConfiguration;
        }

        public override void Execute()
        {
            Task<Settings> configurationTask = droneClient.Configure();
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
    }
}
