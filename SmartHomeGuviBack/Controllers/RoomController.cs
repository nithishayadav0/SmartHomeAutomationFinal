using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Services;

namespace SmartHomeAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomsService;

        public RoomController(RoomService roomsService)
        {
            _roomsService = roomsService;
        }

        // GET: api/Rooms
        [HttpGet]
    
        public async Task<ActionResult<IEnumerable<Rooms>>> GetAllRooms()
        {
            var rooms = await _roomsService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpPost]
      

        public async Task<IActionResult> AddRoom(Rooms room)
        {
            try
            {
                var userId = GetUserIdFromClaims();
                Console.WriteLine($"UserId in AddRoom: {userId}"); // Log the userId here
                room.UserId = userId;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addedRoom = await _roomsService.AddRooms(room);
                return CreatedAtAction(nameof(AddRoom), new { id = room.RoomId }, room);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddRoom: {ex.Message}"); // Log any exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user-rooms")]
     
        public async Task<IActionResult> GetUserRooms()
        {
            try
            {
                var userId = GetUserIdFromClaims();
                if (userId <= 0)
                {
                    return BadRequest("Invalid or missing user ID in token.");
                }

                if (userId == null || userId <= 0)
                {
                    return BadRequest("Invalid user ID.");
                }

                var rooms = await _roomsService.GetRoomsByUser(userId);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        
        
        [HttpGet("roomsbyEmail")]
    
        public async Task<IActionResult> GetRoomsByUsernameAndEmail(string username, string useremail)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(useremail))
                {
                    return BadRequest("Username and user email are required.");
                }

                var rooms = await _roomsService.GetRoomsByUsernameAndEmail(username, useremail);

                if (rooms == null || !rooms.Any())
                {
                    return NotFound("No rooms found for the provided username and email.");
                }

                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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
