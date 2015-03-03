using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.UI
{
    public static class Constants
    {
        public const string OnlineImagePath = @"\Images\online.png";
        public const string OfflineImagePath = @"\Images\offline.png";

        public const string UpCommandMessage = "Go Up";
        public const string DownCommandMessage = "Go Down";
        public const string LeftCommandMessage = "Go Left";
        public const string RightCommandMessage = "Go Right";
        public const string FwdCommandMessage = "Go Forward";
        public const string BwdCommandMessage = "Go Backward";


        public const int NavigationDataPort = 5554;
        public const int VideoStreamPort = 5555;
        public const int MovementControlPort = 5556;
        public const int ConfigurationControlPort = 5559;

    }
}
