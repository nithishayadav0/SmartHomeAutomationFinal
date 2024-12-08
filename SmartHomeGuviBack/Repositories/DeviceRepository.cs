using Microsoft.EntityFrameworkCore;
using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public class DeviceRepository
    {
        private readonly SmartHomeDbContext _context;
        public DeviceRepository(SmartHomeDbContext context)
        {
            _context = context;
        }
        public async Task<Device> AddDeviceAsync(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
            return device;
        }
        public async Task<IEnumerable<Device>> GetDevicesByRoomIdAsync(int roomId)
        {
            return await _context.Devices
                .Where(d => d.RoomId == roomId)
                .ToListAsync();
        }
        public async Task<Device> GetDeviceByIdAsync(int deviceId)
        {
            return await _context.Devices
                .Where(d => d.DeviceId == deviceId)
                .FirstOrDefaultAsync();
        }
        public async Task<Device> UpdateDeviceAsync(Device device)
        {
            var existingDevice = await GetDeviceByIdAsync(device.DeviceId);
            if (existingDevice == null)
            {
                return null;
            }

            existingDevice.Status = device.Status;
            existingDevice.LastUpdated = DateTime.UtcNow;

            _context.Devices.Update(existingDevice);
            await _context.SaveChangesAsync();

            return existingDevice;
        }

        public async Task<Device> UpdateDeviceSpeedAsync(Device device)
        {
            var existingDevice = await GetDeviceByIdAsync(device.DeviceId);
            if (existingDevice == null)
            {
                return null;
            }

            existingDevice.ConfigurationSettings = device.ConfigurationSettings;

            _context.Devices.Update(existingDevice);
            await _context.SaveChangesAsync();

            return existingDevice;
        }
    }
}
