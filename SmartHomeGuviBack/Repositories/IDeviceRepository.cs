using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device> AddDeviceAsync(Device device);
    }
}
