using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Services;

namespace SmartHomeAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase

    {
        private readonly DeviceService _deviceService;
        

        public DeviceController(DeviceService DeviceService)
        {
            _deviceService = DeviceService;
            
        }
        [HttpPost]
        [Authorize(Roles = "Homeowner,Administrator,Guest")]
        public async Task<IActionResult> AddDevice([FromBody] Device device, [FromQuery] int roomId)
        {
            if (roomId <= 0)
            {
                return BadRequest(new { Message = "RoomId is required." });
            }

           

            try
            {
                // Automatically assign RoomId received from query parameters
                device.RoomId = roomId;
                var newDevice = await _deviceService.AddDeviceAsync(device);
                return CreatedAtAction(nameof(AddDevice), new { id = newDevice.DeviceId }, newDevice);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetDevicesByRoomId")]
        [Authorize]
        public async Task<IActionResult> GetDevicesByRoomId([FromQuery] int roomId)
        {
            if (roomId <= 0)
            {
                return BadRequest(new { Message = "Invalid RoomId." });
            }

            try
            {
                var devices = await _deviceService.GetDevicesByRoomIdAsync(roomId);

                if (devices == null || !devices.Any())
                {
                    return NotFound(new { Message = "No devices found for the given RoomId." });
                }

                return Ok(devices);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        //public async Task<IActionResult> UpdateDeviceStatus(int deviceId, [FromBody] Device device)
        //{
        //    if (deviceId != device.DeviceId)
        //    {
        //        return BadRequest(new { Message = "DeviceId mismatch." });
        //    }

        //    try
        //    {

        //        // Update the device status and LastUpdated field
        //        var updatedDevice = await _deviceService.UpdateDeviceStatusAsync(device);
        //        if (updatedDevice == null)
        //        {
        //            return NotFound(new { Message = "Device not found." });
        //        }

        //        return Ok(updatedDevice);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        //    }
        //}
        [HttpPut("UpdateDeviceStatus/{deviceId}")]
        [Authorize(Roles = "Homeowner,Administrator,Guest")]
        public async Task<IActionResult> UpdateDeviceStatus(int deviceId, [FromBody] Device device)
        {
            if (deviceId != device.DeviceId)
            {
                return BadRequest(new { Message = "DeviceId mismatch." });
            }

            try
            {
                // Ensure that device status is updated only if there is an actual change in status
                var updatedDevice = await _deviceService.UpdateDeviceStatusAsync(device);

                if (updatedDevice == null)
                {
                    return NotFound(new { Message = "Device not found." });
                }

                return Ok(updatedDevice);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPut("UpdateDeviceSpeed/{deviceId}")]
        [Authorize(Roles = "Homeowner,Administrator,Guest")]
        public async Task<IActionResult> UpdateDeviceSpeed(int deviceId, [FromBody] Device device)
        {
            if (deviceId != device.DeviceId)
            {
                return BadRequest(new { Message = "DeviceId mismatch." });
            }

            try
            {
                var updatedDevice = await _deviceService.UpdateDeviceSpeedAsync(device);

                if (updatedDevice == null)
                {
                    return NotFound(new { Message = "Device not found." });
                }

                return Ok(updatedDevice);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        

        private int GetUserIdFromClaims()
        {
            var userIdClaim = User?.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId; // Return the parsed userId
            }
            throw new Exception("User ID not found in token claims."); // Throw exception 
        }

    }


}
