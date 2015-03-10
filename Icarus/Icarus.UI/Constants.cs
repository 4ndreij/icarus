using Icarus.Core.DroneConfiguration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.UI
{
    public static class Constants
    {
        public const string OnlineImagePath = @"\Images\online.png";
        public const string OfflineImagePath = @"\Images\offline.png";

        public static DroneConfiguration DroneConfiguration
            = new DroneConfiguration()
            {
                HostName = ConfigurationManager.AppSettings["droneHostName"]
            };

        public const int NavigationDataPort = 5554;
        public const int VideoStreamPort = 5555;
        public const int MovementControlPort = 5556;
        public const int ConfigurationControlPort = 5559;

    }
}
