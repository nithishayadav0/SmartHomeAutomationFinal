using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Services;

namespace SmartHomeAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceMaintenanceController : ControllerBase
    {
        private readonly IDeviceMaintenanceService _deviceMaintenanceService;

        public DeviceMaintenanceController(IDeviceMaintenanceService deviceMaintenanceService)
        {
            _deviceMaintenanceService = deviceMaintenanceService;
        }


        [HttpPost("create")]
        [Authorize(Roles = "Homeowner,Guest")]
        public async Task<IActionResult> CreateMaintenanceRequest([FromBody] DeviceMaintenance maintenanceRequest, [FromQuery] int deviceId)
        {
            if (maintenanceRequest == null)
            {
                return BadRequest("Invalid maintenance request.");
            }

            
            maintenanceRequest.DeviceId = deviceId;
            maintenanceRequest.Status = "pending";

            // Creating the maintenance request using the service
            var createdMaintenance = await _deviceMaintenanceService.CreateMaintenanceRequestAsync(maintenanceRequest);

            // Returning  a CreatedAtAction response with the newly created maintenance
            return CreatedAtAction(nameof(CreateMaintenanceRequest), new { id = createdMaintenance.MaintenanceId }, createdMaintenance);
        }
        [HttpGet("maintenance")]
        [Authorize(Roles = "DeviceTechnician,Homeowner,Guest")]
        public async Task<IActionResult> GetMaintenanceRequestsForUser()
        {
            // Retrieve the UserId from Claims (assuming you're using JWT)
            var currentUserId = GetUserIdFromClaims();
            // If UserId from Claims doesn't match the UserId provided in the route, return Unauthorized
            if (currentUserId == null )
            {
                return Unauthorized("You are not authorized to view this data.");
            }

            var maintenanceRequests = await _deviceMaintenanceService.GetMaintenanceRequestsForUserAsync(currentUserId);

            if (maintenanceRequests == null || !maintenanceRequests.Any())
            {
                return NotFound("No maintenance requests found for this user.");
            }

            return Ok(maintenanceRequests);
        }


        //Getting all the Maintennace Requests

        [HttpGet("all-maintenance")]
        [Authorize(Roles = "DeviceTechnician")]
        public async Task<IActionResult> GetAllMaintenanceRequests()
        {
            var maintenanceRequests = await _deviceMaintenanceService.GetAllMaintenanceRequestsWithUserDetailsAsync();

            if (maintenanceRequests == null || !maintenanceRequests.Any())
            {
                return NotFound("No maintenance requests found.");
            }

            return Ok(maintenanceRequests);
        }




        //Updating The status of the maintenace using Id
        [HttpPut("update-status/{maintenanceId}")]
        [Authorize(Roles = "DeviceTechnician")]
        public async Task<IActionResult> UpdateMaintenanceStatus(int maintenanceId, [FromBody] MaintenanceStatusUpdate statusUpdate)
        {
            if (statusUpdate == null || string.IsNullOrEmpty(statusUpdate.Status))
            {
                return BadRequest("Status cannot be null or empty.");
            }

            var success = await _deviceMaintenanceService.UpdateMaintenanceStatusAsync(maintenanceId, statusUpdate.Status);
            if (!success)
            {
                return NotFound($"Maintenance request with ID {maintenanceId} not found.");
            }

            return Ok(new { message = "Maintenance status updated successfully." });
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
      
        [HttpGet("run-diagnostics/{deviceId}")]
        [Authorize(Roles = "DeviceTechnician")]
        public async Task<IActionResult> RunDiagnostics(int deviceId)
        {
            var diagnosticsReport = await _deviceMaintenanceService.GetDiagnosticsReportAsync(deviceId);

            if (diagnosticsReport == null)
            {
                return NotFound($"No diagnostics found for device {deviceId}");
            }

            return Ok(diagnosticsReport);
        }


      

        [HttpPost("run-diagnostics/{deviceId}")]
        [Authorize(Roles = "DeviceTechnician")]
        public async Task<IActionResult> UpdateDiagnostics(int deviceId, [FromBody] DiagnosticsReport diagnosticsReport)
        {
            if (diagnosticsReport == null)
            {
                return BadRequest("Diagnostics report data cannot be null.");
            }

            var success = await _deviceMaintenanceService.UpdateDiagnosticsReportAsync(deviceId, diagnosticsReport);
            

            return Ok(new { message = "Diagnostics updated successfully." });
        }

    }
}