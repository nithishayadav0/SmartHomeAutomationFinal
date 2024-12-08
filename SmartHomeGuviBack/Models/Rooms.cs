using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartHomeAutomation.Models
{
    public class Rooms
    {
        [Key] // Marks RoomId as the primary key
        public int RoomId { get; set; }

        [Required] // Name is required
        [MaxLength(100)] // Maximum length for the Name field
        public string Name { get; set; }

        public int Floor { get; set; }

        public int ZoneId { get; set; }

        [MaxLength(50)] // Maximum length for the RoomType field
        public string RoomType { get; set; }

      
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [JsonIgnore]
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
