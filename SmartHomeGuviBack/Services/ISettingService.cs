using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Services
{
    public interface ISettingService
    {
        Task<Settings> GetSettingsAsync();
        Task UpdateAudioCommandsStateAsync(bool allowAudioCommands);
    }
}
