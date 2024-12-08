using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Services
{
    public interface ISecurityService
    {
        Task UpdateStatusAsync(string status);
        Task<List<SecurityDevice>> GetAllSecurityDevicesAsync();
        Task<IEnumerable<string>> GetCurrentDetectionsAsync();
    }
}
