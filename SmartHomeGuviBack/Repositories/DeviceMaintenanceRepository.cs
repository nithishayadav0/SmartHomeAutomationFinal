using Microsoft.EntityFrameworkCore;
using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public class DeviceMaintenanceRepository :IDeviceMaintenanceRepository
    {
        private readonly SmartHomeDbContext _context;

        public DeviceMaintenanceRepository(SmartHomeDbContext context)
        {
            _context = context;
        }

        // Add a new device maintenance record to the database
        public async Task<DeviceMaintenance> AddDeviceMaintenanceAsync(DeviceMaintenance maintenance)
        {
            // Add the maintenance request to the database
            await _context.DeviceMaintenances.AddAsync(maintenance);
            await _context.SaveChangesAsync();
            return maintenance;
        }
    
        public async Task<IEnumerable<object>> GetMaintenanceRequestsForUserAsync(int userId)
        {
            // Fetch the maintenance requests along with the device name and room name
            var maintenanceRequests = await _context.DeviceMaintenances
                .Where(m => m.Device.Room.UserId == userId)  // Filter based on the UserId
                .Select(m => new
                {
                    m.MaintenanceId,
                    m.DeviceId,
                    DeviceName = m.Device.Name,           // Include Device Name
                    RoomName = m.Device.Room.Name,        // Include Room Name
                    m.MaintenanceType,
                    m.Status
                })
                .ToListAsync();

            return maintenanceRequests;
        }
        public async Task<IEnumerable<object>> GetAllMaintenanceRequestsWithUserDetailsAsync()
        {
            var maintenanceRequests = await _context.DeviceMaintenances
                .Include(m => m.Device)                // Include Device navigation property
                .ThenInclude(d => d.Room)             // Include Room navigation property
                .ThenInclude(r => r.User)             // Include User navigation property
                .Select(m => new
                {
                    m.MaintenanceId,
                    m.DeviceId,
                    DeviceName = m.Device.Name,       // Device Name
                    RoomName = m.Device.Room.Name,   // Room Name
                    m.MaintenanceType,
                    m.Status,
                    Username = m.Device.Room.User.Username, // User's Username
                    UserEmail = m.Device.Room.User.Email    // User's Email
                })
                .ToListAsync();

            return maintenanceRequests;
        }

        public async Task<DeviceMaintenance> GetByIdAsync(int maintenanceId)
        {
            return await _context.DeviceMaintenances
                .FirstOrDefaultAsync(m => m.MaintenanceId == maintenanceId);
        }

        public async Task UpdateAsync(DeviceMaintenance maintenanceRequest)
        {
            _context.DeviceMaintenances.Update(maintenanceRequest);
            await _context.SaveChangesAsync();
        }
        public async Task<DiagnosticsReport> GetDiagnosticsReportAsync(int deviceId)
        {
            return await _context.DiagnosticsReports
                .Where(d => d.DeviceId == deviceId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateDiagnosticsReportAsync(DiagnosticsReport diagnosticsReport)
        {
            var existingReport = await GetDiagnosticsReportAsync(diagnosticsReport.DeviceId);
            if (existingReport != null)
            {
                existingReport.BatteryLevel = diagnosticsReport.BatteryLevel;
                existingReport.ConnectivityStatus = diagnosticsReport.ConnectivityStatus;
                existingReport.FirmwareVersion = diagnosticsReport.FirmwareVersion;
                existingReport.LastUpdated = DateTime.Now;

                _context.DiagnosticsReports.Update(existingReport);
            }
            else
            {
                _context.DiagnosticsReports.Add(diagnosticsReport);
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
