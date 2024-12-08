using System.ComponentModel.DataAnnotations;

namespace SmartHomeAutomation.Models
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Email should be required.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password should be  required.")]
        [StringLength(100)]
        public string? Password { get; set; }
    }
}
