using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Services;
using System.Threading.Tasks;

namespace SmartHomeAutomation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GlobalAutomationController : ControllerBase
    {
        private readonly IGlobalAutomationService _service;

        public GlobalAutomationController(IGlobalAutomationService service)
        {
            _service = service;
        }

        // Adding the Global Automation Rules
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddGlobalAutomation([FromBody] GlobalAutomation automation)
        {
            if (automation == null)
            {
                return BadRequest("Invalid data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.AddAutomationAsync(automation);
                return CreatedAtAction(nameof(GetAllAutomations), new { id = automation.GlobalAutomationId }, automation);
            }
            catch
            {
                return StatusCode(500, "An error occurred while saving the automation.");
            }
        }


        // Getting all the automations

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllAutomations()
        {
            try
            {
                var automations = await _service.GetAllAutomationsAsync();

                if (automations == null || !automations.Any())
                {
                    return NotFound("No automations found.");
                }

                return Ok(automations);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching the automations.");
            }
        }
       
    }
}
