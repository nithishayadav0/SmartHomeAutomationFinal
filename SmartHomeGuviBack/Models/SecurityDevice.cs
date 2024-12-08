using System.ComponentModel.DataAnnotations;

namespace SmartHomeAutomation.Models
{


    public class SecurityDevice
    {
        [Key]
        public int SecurityDeviceId { get; set; }

        [Required(ErrorMessage = "Device type is required.")]
        [StringLength(50, ErrorMessage = "Device type must be a maximum of 50 characters.")]
        public string Type { get; set; } //  ( Camera, Motion Detector)

        [Required(ErrorMessage = "Device status is required.")]
        [RegularExpression(@"^(On|Off)$", ErrorMessage = "Status must be either 'On' or 'Off'.")]
        public string Status { get; set; } // (On/Off)

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, ErrorMessage = "Location name must be a maximum of 100 characters.")]
        public string Location { get; set; } // Device's physical location


        public string? DetectionHistory { get; set; }

        [Required(ErrorMessage = "Alert status is required.")]
        [RegularExpression(@"^(Active|Resolved|Pending)$", ErrorMessage = "Alert status must be 'Active', 'Resolved', or 'Pending'.")]
        public string AlertStatus { get; set; } // Alert status (Active/Resolved/Pending)
    }

}

