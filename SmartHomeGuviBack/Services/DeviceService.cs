using SmartHomeAutomation.Models;
using SmartHomeAutomation.Repositories;

namespace SmartHomeAutomation.Services
{
    public class DeviceService
    {

        private readonly DeviceRepository _deviceRepository;

        public DeviceService(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task<Device> AddDeviceAsync(Device device)
        {
            return await _deviceRepository.AddDeviceAsync(device);
        }
        public async Task<IEnumerable<Device>> GetDevicesByRoomIdAsync(int roomId)
        {
            return await _deviceRepository.GetDevicesByRoomIdAsync(roomId);
        }
        public async Task<Device> UpdateDeviceStatusAsync(Device device)
        {
            // Use the repository to update the device
            var updatedDevice = await _deviceRepository.UpdateDeviceAsync(device);
            return updatedDevice;
        }
        public async Task<Device> UpdateDeviceSpeedAsync(Device device)
        {
            // Use the repository to update the device
            var updatedDevice = await _deviceRepository.UpdateDeviceSpeedAsync(device);
            return updatedDevice;
        }
    }
}

