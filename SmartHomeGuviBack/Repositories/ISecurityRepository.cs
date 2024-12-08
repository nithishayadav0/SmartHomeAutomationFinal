using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public interface ISecurityRepository
    {
        Task<List<SecurityDevice>> GetAllSecurityDevicesAsync();
        Task UpdateStatusAsync(string status);
        Task SaveChangesAsync();

    }
}
