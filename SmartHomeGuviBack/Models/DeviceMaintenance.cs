using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SmartHomeAutomation.Models
{
    public class DeviceMaintenance
    {
        [Key]
        public int MaintenanceId { get; set; }

        [Required]
        public int DeviceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MaintenanceType { get; set; }



        public string Status { get; set; } = "pending";

        [ForeignKey("DeviceId")]
        [JsonIgnore]
        [ValidateNever]
        public virtual Device Device { get; set; }
    }
}
