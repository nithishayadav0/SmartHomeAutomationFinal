namespace SmartHomeAutomation.Models
{
    public class DiagnosticsReport
    {
        public int DeviceId { get; set; }
        public string BatteryLevel { get; set; }
        public string ConnectivityStatus { get; set; }
        public string FirmwareVersion { get; set; }
        public DateTime LastUpdated { get; set; }
        public virtual Device? Device { get; set; }
    }
}
