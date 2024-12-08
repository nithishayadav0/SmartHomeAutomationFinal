using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Services
{
    public interface IAutomationService
    {
        Task<IEnumerable<Automation>> GetAutomationsByUserIdAsync(int userId);
        Task<bool> CheckDeviceExistsAsync(int deviceId);
        Task<Automation> CreateAutomationAsync(Automation automation);
        Task<bool> DeleteAutomationAsync(int id);
    }

}
