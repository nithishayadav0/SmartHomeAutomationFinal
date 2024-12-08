using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Data;

namespace SmartHomeAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
        public class NotificationsController : ControllerBase
        {
            private readonly SmartHomeDbContext _context;

            public NotificationsController(SmartHomeDbContext context)
            {
                _context = context;
            }


            [HttpGet]
            [Authorize(Roles = "Homeowner,Guest,Administrator")]
        public IActionResult GetNotificationsByUserId()
            {
                try
                {
                int userId = GetUserIdFromClaims();

                    // Check if the user exists
                    var userExists = _context.Users.Any(u => u.UserId == userId);
                    if (!userExists)
                    {
                        return NotFound(new { message = $"User with ID {userId} not found." });
                    }

                    // Retrieve notifications for the given UserId
                    var notifications = _context.Notifications
                        .Where(n => n.UserId == userId)
                        .OrderByDescending(n => n.Timestamp) // Optional: Order by the most recent notifications
                        .Select(n => new
                        {
                            n.NotificationId,
                            n.Type,
                            n.Message,
                            n.Timestamp
                        })
                        .ToList();

                    if (notifications.Count == 0)
                    {
                        return Ok(new { message = "No notifications found for the user.", notifications = notifications });
                    }

                    return Ok(new { message = "Notifications retrieved successfully.", notifications = notifications });
                }
                catch (Exception ex)
                {
                    // Log the error (logging mechanism can be implemented here)
                    return StatusCode(500, new { message = "An error occurred while retrieving notifications.", error = ex.Message });
                }
            }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Homeowner,Guest,Administrator")]
        public IActionResult DeleteNotification(int id)
        {
            var notification = _context.Notifications.FirstOrDefault(n => n.NotificationId == id);

            if (notification == null)
            {
                return NotFound(new { message = "Notification not found." });
            }

            _context.Notifications.Remove(notification);
            _context.SaveChanges();

            return Ok(new { message = "Notification deleted successfully." });
        }
    
    private int GetUserIdFromClaims()
        {
            var userIdClaim = User?.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId; // Return the parsed userId
            }
            throw new Exception("User ID not found in token claims."); // Throw exception for debugging
        }

    }
}



