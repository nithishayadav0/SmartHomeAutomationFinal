using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartHomeAutomation.Models
{
    public class Device
    {
        [Key] 
        public int DeviceId { get; set; }

        [Required] 
        [MaxLength(100)]
        public string Name { get; set; }

        [Required] 
        [MaxLength(50)] 
        public string Type { get; set; }

        [MaxLength(100)] // Maximum length for the Location field (can be specific within the room)
        public string Location { get; set; }

        [Required] 
        [MaxLength(50)] // Maximum length for the Status field
        public string Status { get; set; }

        public string ConfigurationSettings { get; set; }

        public DateTime LastUpdated { get; set; }

        public int RoomId { get; set; }

        // Navigation property to access the associated room
        [JsonIgnore] // to avoid circular references during JSON serialization
        public virtual Rooms? Room { get; set; }
        [JsonIgnore]
        public virtual ICollection<Automation>? Automations { get; set; }

        [JsonIgnore]
        public virtual ICollection<DeviceMaintenance>? DeviceMaintenances { get; set; }

        [JsonIgnore]
        public virtual DiagnosticsReport? DiagnosticsReport { get; set; }


        [JsonIgnore]
        public virtual ICollection<EnergyUsage>? EnergyUsages { get; set; }

    }
}
