using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SmartHomeAutomation.Models
{
    public class Automation
    {
        [Key]
        public int AutomationId { get; set; }

        [Required]
        public int DeviceId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TriggerEvent { get; set; }  // e.g., "TimeSchedule", "TemperatureChange", etc.

        [Required]
        [MaxLength(50)]
        public string Action { get; set; }  // e.g., "TurnOff", "TurnOn"

        [Required]
        public TimeSpan TimeSchedule { get; set; }  // Scheduled time (e.g., "22:00" for 10 PM)

        [Required]
        public string Status { get; set; }

        [JsonIgnore]
     
        public virtual Device? Device { get; set; }
    }
}
