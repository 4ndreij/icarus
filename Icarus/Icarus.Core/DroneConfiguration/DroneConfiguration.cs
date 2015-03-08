namespace Icarus.Core.DroneConfiguration
{
    public class DroneConfiguration
    {
        public string HostName { get; set; }
        public int ConfigurationControlPort { get; set; }
        public int NavigationDataPort { get; set; }
        public int NavigationDataTimeout { get; set; }
        public int KeepAliveTimeout { get; set; }
        public int MovementCommandPort { get; set; }
        public int VideoStreamPort { get; set; }
    }
}