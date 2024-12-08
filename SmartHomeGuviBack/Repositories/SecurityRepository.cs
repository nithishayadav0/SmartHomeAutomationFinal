using Microsoft.EntityFrameworkCore;
using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly SmartHomeDbContext _context;

        public SecurityRepository(SmartHomeDbContext context)
        {
            _context = context;
        }


        public async Task<List<SecurityDevice>> GetAllSecurityDevicesAsync()
        {
            return await _context.SecurityDevices.ToListAsync();
        }
        public async Task UpdateStatusAsync(string status)
        {
            var devices = await _context.SecurityDevices.ToListAsync();

            foreach (var device in devices)
            {
                device.Status = status;
            }

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
