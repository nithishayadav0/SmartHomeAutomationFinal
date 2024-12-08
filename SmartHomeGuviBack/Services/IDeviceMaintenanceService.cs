using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Services
{
    public interface IDeviceMaintenanceService
    {
        Task<IEnumerable<Object>> GetMaintenanceRequestsForUserAsync(int userId);
        Task<DeviceMaintenance> CreateMaintenanceRequestAsync(DeviceMaintenance maintenance);
        Task<IEnumerable<object>> GetAllMaintenanceRequestsWithUserDetailsAsync();
        Task<DeviceMaintenance> GetMaintenanceRequestByIdAsync(int maintenanceId);
        Task<bool> UpdateMaintenanceStatusAsync(int maintenanceId, string status);
        Task<DiagnosticsReport> GetDiagnosticsReportAsync(int deviceId);
        Task<bool> UpdateDiagnosticsReportAsync(int deviceId, DiagnosticsReport diagnosticsReport);
    }
}
