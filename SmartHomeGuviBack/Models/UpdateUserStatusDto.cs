using System.ComponentModel.DataAnnotations;

namespace SmartHomeAutomation.Models
{
    public class UpdateUserStatusDto
    {
        [Required]
        public bool IsActive { get; set; }
    }

}
