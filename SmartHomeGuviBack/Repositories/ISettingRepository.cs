using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public interface ISettingRepository
    {
        Task<Settings> GetSettingsAsync();
        Task UpdateSettingsAsync(Settings settings);
    }
}
