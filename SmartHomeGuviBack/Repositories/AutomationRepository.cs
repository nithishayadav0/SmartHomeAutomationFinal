using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartHomeAutomation.Repositories
{
    public class AutomationRepository : IAutomationRepository
    {
        private readonly SmartHomeDbContext _context;

        public AutomationRepository(SmartHomeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Automation>> GetAutomationsByUserIdAsync(int userId)
        {
            // Get all rooms belonging to the user
            var roomIds = await _context.Rooms
                .Where(r => r.UserId == userId)
                .Select(r => r.RoomId)
                .ToListAsync();

            // Get all devices in those rooms, including the related Room for each Device
            var devices = await _context.Devices
                .Where(d => roomIds.Contains(d.RoomId))
                .Include(d => d.Room)  // Include the related Room for each Device
                .ToListAsync();

            // Get all automations for those devices
            var deviceIds = devices.Select(d => d.DeviceId).ToList();
            var automations = await _context.Automations
                .Where(a => deviceIds.Contains(a.DeviceId))
                .Include(a => a.Device)  // Include the related Device for each Automation
                .ToListAsync();

            return automations;
        }
        public async Task<Automation> AddAutomationAsync(Automation automation)
        {
            // Add the automation entity to the context and save changes
            _context.Automations.Add(automation);
            await _context.SaveChangesAsync();

            return automation;
        }
        public async Task<Automation> GetAutomationByIdAsync(int id)
        {
            return await _context.Automations
                                 .FirstOrDefaultAsync(a => a.AutomationId == id);
        }
        public async Task<bool> DeleteAutomationAsync(int id)
        {
            var automation = await GetAutomationByIdAsync(id);
            if (automation == null) return false;

            _context.Automations.Remove(automation);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
