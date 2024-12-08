using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartHomeAutomation.Models
{
    public class User
    {

        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Password hash cannot exceed 255 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [RegularExpression("^(Homeowner|Administrator|Guest|DeviceTechnician)$",
            ErrorMessage = "Role must be one of the following: Homeowner, Administrator, Guest, DeviceTechnician")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }

        [JsonIgnore]
        public virtual ICollection<Rooms> Rooms { get; set; } = new List<Rooms>();  // One User has many Rooms
        
        [JsonIgnore]
        public virtual ICollection<Notification>? Notifications { get; set; }  // One User has many Notifications
    }
}
