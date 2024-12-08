using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public interface IDeviceMaintenanceRepository
    {
        Task<DeviceMaintenance> AddDeviceMaintenanceAsync(DeviceMaintenance maintenance);
        Task<IEnumerable<object>> GetMaintenanceRequestsForUserAsync(int userId);
        Task<IEnumerable<object>> GetAllMaintenanceRequestsWithUserDetailsAsync();

        Task<DeviceMaintenance> GetByIdAsync(int maintenanceId);
        Task UpdateAsync(DeviceMaintenance maintenanceRequest);
        Task<DiagnosticsReport> GetDiagnosticsReportAsync(int deviceId);
        Task<bool> UpdateDiagnosticsReportAsync(DiagnosticsReport diagnosticsReport);


    }
}
