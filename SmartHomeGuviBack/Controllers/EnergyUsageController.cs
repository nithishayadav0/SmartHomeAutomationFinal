using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Data;
using SmartHomeAutomation.Services;

namespace SmartHomeAutomation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EnergyUsageController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;
        private readonly EnergyMonthlyUsageService _energyMonthlyUsageService;

        
        public EnergyUsageController(SmartHomeDbContext context, EnergyMonthlyUsageService energyMonthlyUsageService)
        {
            _context = context;
            _energyMonthlyUsageService = energyMonthlyUsageService;
        }

        [HttpGet("usage-report")]
        [Authorize(Roles = "Homeowner,Guest,Administrator")]
        public IActionResult GetUsageReport()
        {
            var currentUserId = GetUserIdFromClaims();

            var report = _context.EnergyUsages
                .Where(e => e.Device.Room.UserId == currentUserId)  // Filter by current user ID
                .GroupBy(e => e.DeviceId)
                .Select(g => new
                {
                    DeviceName = g.FirstOrDefault().Device.Name,  // Get device name
                    RoomName = g.FirstOrDefault().Device.Room.Name,  // Get room name associated with the device
                    TotalConsumption = g.Sum(x => x.Consumption),  // Sum of all consumption for the device
                    TotalCost = g.Sum(x => x.EnergyCost)  // Sum of all energy cost for the device
                })
                .ToList();

            if (report.Any())  // Check if the report has any data
            {
                return Ok(report);  // Return the report data
            }
            else
            {
                return NotFound("No report found");  // Return a not found response if no data
            }
        }
        [HttpGet("GetMonthlyEnergyReport")]
         [Authorize(Roles = "Administrator,Homeowner,Guest")]
        public async Task<IActionResult> GetMonthlyEnergyReport([FromQuery] string userEmail)
        {
            try
            {
                var energyReport = await _energyMonthlyUsageService.GetMonthlyEnergyReportByUserEmail(userEmail);
                if (energyReport == null || !energyReport.Any())
                {
                    return NotFound(new { Message = "No energy data found for the given user." });
                }
                return Ok(energyReport);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error fetching energy report", Details = ex.Message });
            }
        }

        private int GetUserIdFromClaims()
        {
            var userIdClaim = User?.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId; // Return the parsed userId
            }
            else
            {
                Console.WriteLine("User Id is Null");
                return 0;
            }
        }

    }
}
