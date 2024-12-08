using System.ComponentModel.DataAnnotations;

namespace SmartHomeAutomation.Models
{
   
        public class GlobalAutomation
        {
            [Key]
            public int GlobalAutomationId { get; set; }

            [Required]
            [MaxLength(100)]
            public string TriggerEvent { get; set; }  // e.g., "Sunset", "TemperatureChange"

            [Required]
            [MaxLength(50)]
            public string Action { get; set; }  // e.g., "TurnOffLights", "ActivateSecurity"

            [Required]
            public TimeSpan? TimeSchedule { get; set; }  

            [Required]
            [MaxLength(20)]
            public string Status { get; set; }  // e.g., "Active", "Inactive"

            [MaxLength(255)]
            public string Description { get; set; }  // A brief description of the automation

           
        }
    }

