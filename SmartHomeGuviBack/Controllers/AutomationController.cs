using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Services;

namespace SmartHomeAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomationController : ControllerBase
       
    {
        private readonly IAutomationService _automationService;
        public AutomationController(IAutomationService automationService)
        {
            _automationService = automationService;
        }

        
        [HttpGet]
        [Authorize(Roles = "Homeowner,Guest,Administrator")]
        public async Task<ActionResult<IEnumerable<Automation>>> GetAutomations()
        {
            try
            {
                var userId = GetUserIdFromClaims();
                if (userId <= 0)
                {
                    return BadRequest("Invalid or missing user ID in token.");
                }

                // Fetch automations with related Device and Room data using service
                var automations = await _automationService.GetAutomationsByUserIdAsync(userId);

                if (automations == null || !automations.Any())
                {
                    return NotFound("No automations found for the specified user.");
                }

                // Select and return automations with additional deviceName and roomName
                var automationsWithDetails = automations.Select(automation => new
                {
                    automation.AutomationId,
                    automation.TriggerEvent,
                    automation.TimeSchedule,
                    automation.Action,
                    automation.Status,
                    deviceName = automation.Device.Name,  // Get device name
                    roomName = automation.Device.Room.Name  // Get room name from Device
                }).ToList();

                return Ok(automationsWithDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Authorize(Roles = "Homeowner,Administrator,Guest")]
        public async Task<ActionResult<Automation>> CreateAutomation([FromQuery] int deviceId, [FromBody] Automation automation)
        {
            try
            {
                if (deviceId <= 0)
                {
                    return BadRequest("Device ID is required and must be greater than 0.");
                }

                // Set the deviceId for the automation from the query parameter
                automation.DeviceId = deviceId;

                // Validate the provided automation object (ensure it contains required data)
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if the device with the given deviceId exists using the service
                var deviceExists = await _automationService.CheckDeviceExistsAsync(deviceId);
                if (!deviceExists)
                {
                    return NotFound("Device not found for the given deviceId.");
                }

                // Create and save the new automation using the service
                var createdAutomation = await _automationService.CreateAutomationAsync(automation);

                return CreatedAtAction(nameof(GetAutomations), new { id = createdAutomation.AutomationId }, createdAutomation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Homeowner,Administrator,Guest")]
        public async Task<IActionResult> DeleteAutomation(int id)
        {
            var success = await _automationService.DeleteAutomationAsync(id);
            if (!success)
            {
                return NotFound(); // Return 404 if automation not found
            }

            return NoContent(); // Return 204 No Content on successful deletion
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
