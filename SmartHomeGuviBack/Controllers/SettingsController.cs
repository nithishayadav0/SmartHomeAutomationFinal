using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Services;

namespace SmartHomeAutomation.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingsService;

        public SettingsController(ISettingService settingsService)
        {
            _settingsService = settingsService;
        }

        // Endpoint to get current settings
        [HttpGet]

        public async Task<ActionResult<Settings>> GetSettings()
        {
            var settings = await _settingsService.GetSettingsAsync();
            return Ok(settings); // Return the current settings
        }

        // Endpoint to update audio commands state
        [HttpPost("toggleAudioCommands")]
        public async Task<IActionResult> ToggleAudioCommands([FromBody] bool allowAudioCommands)
        {
            await _settingsService.UpdateAudioCommandsStateAsync(allowAudioCommands);
            return Ok(); // Respond with success
        }
    }

}
