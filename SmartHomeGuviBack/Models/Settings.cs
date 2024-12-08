using System.ComponentModel.DataAnnotations;

namespace SmartHomeAutomation.Models
{
    public class Settings
    {
        [Key]
        public int Id { get; set; } 
        public bool AllowAudioCommands { get; set; } 

        public bool AllowEnergyNotify { get; set; } 

        public bool AllowNotify { get; set; } 
    }
}
