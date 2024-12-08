using System.Text.Json.Serialization;

namespace SmartHomeAutomation.Models
{
    
        public class Notification
        {
            // Primary key for the notification
            public int NotificationId { get; set; }

            // Type of the notification (e.g., Info, Warning, Error)
            public string Type { get; set; }

            // Notification message
            public string Message { get; set; }

            // Timestamp indicating when the notification was created
            public DateTime Timestamp { get; set; }

            // Foreign key to associate the notification with a user
            public int UserId { get; set; }

        // Navigation property to reference the user
            [JsonIgnore]
            public virtual User? User { get; set; }
        }
    }



