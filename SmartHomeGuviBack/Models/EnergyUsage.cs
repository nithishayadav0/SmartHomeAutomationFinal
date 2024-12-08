using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SmartHomeAutomation.Models
{
    public class EnergyUsage
    {
        [Key]
        public int UsageId { get; set; }

        [Required]
        public int DeviceId { get; set; }

        [Required]
        public double Consumption { get; set; } // in kWh or similar

        [Required]
        public DateTime TimePeriod { get; set; } // e.g., "2024-12-03 12:00:00"

        [Required]
        public decimal EnergyCost { get; set; } // in currency units

        // Navigation property
        [JsonIgnore]
        [ValidateNever]
        public virtual Device? Device { get; set; }
    }
}
