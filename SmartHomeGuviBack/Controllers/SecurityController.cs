using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Services;

namespace SmartHomeAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        // PUT: api/SecurityDevices/UpdateStatusToOn
        [HttpPut("UpdateStatus/{status}")]
        [Authorize(Roles = "Administrator,Homeowner,Guest")]
        public async Task<IActionResult> UpdateStatus(string status)
        {
            if (status != "On" && status != "Off")
            {
                return BadRequest("Invalid status. Status must be 'On' or 'Off'.");
            }

            await _securityService.UpdateStatusAsync(status);
            return NoContent(); // 204 No Content response to indicate successful update
        }


        [HttpGet]
        [Authorize(Roles = "Administrator,Homeowner,Guest")]
        public async Task<ActionResult<IEnumerable<SecurityDevice>>> GetAllSecurityDevices()
        {
            var devices = await _securityService.GetAllSecurityDevicesAsync();
            return Ok(devices); // 200 OK with the list of devices
        }
        [HttpGet("current-detections")]
        [Authorize(Roles = "Administrator,Homeowner,Guest")]
        public async Task<string> GetCurrentDetectionsAsync()
        {
            var devices = await _securityService.GetAllSecurityDevicesAsync();
            string latestDetection = string.Empty;
            DateTime latestTimestamp = DateTime.MinValue;

            foreach (var device in devices)
            {
                if (!string.IsNullOrEmpty(device.DetectionHistory))
                {
                    var events = device.DetectionHistory
                        .Split('|', StringSplitOptions.TrimEntries) // Split by delimiter
                        .Select(evt =>
                        {
                            // Extract timestamp and return a tuple of timestamp and event
                            var timestampEnd = evt.IndexOf(']');
                            if (timestampEnd > 0 && DateTime.TryParseExact(
                                evt.Substring(1, timestampEnd - 1), // Extract timestamp
                                "dd-MM-yyyy HH:mm:ss",
                                null,
                                System.Globalization.DateTimeStyles.None,
                                out var timestamp))
                            {
                                return (Timestamp: timestamp, Event: evt);
                            }
                            return (Timestamp: DateTime.MinValue, Event: string.Empty);
                        })
                        .Where(t => t.Timestamp != DateTime.MinValue) // Filter valid timestamps
                        .ToList();

                    // Find the latest event from the device
                    var latestDeviceEvent = events.OrderByDescending(t => t.Timestamp).FirstOrDefault();

                    if (latestDeviceEvent.Timestamp > latestTimestamp)
                    {
                        latestTimestamp = latestDeviceEvent.Timestamp;
                        latestDetection = $"[{device.Type} in {device.Location}] {latestDeviceEvent.Event.Trim()}";
                    }
                }
            }
           
           return latestDetection;
        }





    }
}

