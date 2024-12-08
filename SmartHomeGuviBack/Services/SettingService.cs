using SmartHomeAutomation.Models;
using SmartHomeAutomation.Repositories;

namespace SmartHomeAutomation.Services
{
    public class SettingService:ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingsRepository)
        {
            _settingRepository = settingsRepository;
        }

        // Get current settings
        public async Task<Settings> GetSettingsAsync()
        {
            return await _settingRepository.GetSettingsAsync();
        }

        // Update audio commands state
        public async Task UpdateAudioCommandsStateAsync(bool allowAudioCommands)
        {
            var settings = await _settingRepository.GetSettingsAsync();

           
               
                settings.AllowAudioCommands = allowAudioCommands;
                await _settingRepository.UpdateSettingsAsync(settings);
            
        }
    }
}
