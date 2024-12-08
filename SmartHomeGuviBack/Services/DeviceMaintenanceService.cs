using SmartHomeAutomation.Models;
using SmartHomeAutomation.Repositories;

namespace SmartHomeAutomation.Services
{
    public class DeviceMaintenanceService:IDeviceMaintenanceService
    {
        private readonly IDeviceMaintenanceRepository _maintenanceRepository;


        public DeviceMaintenanceService(IDeviceMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        // Create a new device maintenance request
        public async Task<DeviceMaintenance> CreateMaintenanceRequestAsync(DeviceMaintenance maintenance)
        {
            // Call the repository to add the maintenance request
            return await _maintenanceRepository.AddDeviceMaintenanceAsync(maintenance);
        }
        public async Task<IEnumerable<Object>> GetMaintenanceRequestsForUserAsync(int userId)
        {
            // Call the repository to get the maintenance requests for the user
            return await _maintenanceRepository.GetMaintenanceRequestsForUserAsync(userId);
        }
        public async Task<IEnumerable<object>> GetAllMaintenanceRequestsWithUserDetailsAsync()
        {
            // Call the repository to get all maintenance requests with user details
            return await _maintenanceRepository.GetAllMaintenanceRequestsWithUserDetailsAsync();
        }
        public async Task<DeviceMaintenance> GetMaintenanceRequestByIdAsync(int maintenanceId)
        {
            return await _maintenanceRepository.GetByIdAsync(maintenanceId);
        }

        public async Task<bool> UpdateMaintenanceStatusAsync(int maintenanceId, string status)
        {
            var maintenanceRequest = await GetMaintenanceRequestByIdAsync(maintenanceId);
            if (maintenanceRequest == null)
            {
                return false; // Not found
            }

            // Update the status
            maintenanceRequest.Status = status;

            // Save changes to the database
            await _maintenanceRepository.UpdateAsync(maintenanceRequest);

            return true; // Success
        }
        public async Task<DiagnosticsReport> GetDiagnosticsReportAsync(int deviceId)
        {
            return await _maintenanceRepository.GetDiagnosticsReportAsync(deviceId);
        }

        public async Task<bool> UpdateDiagnosticsReportAsync(int deviceId, DiagnosticsReport diagnosticsReport)
        {
            diagnosticsReport.DeviceId = deviceId;
            return await _maintenanceRepository.UpdateDiagnosticsReportAsync(diagnosticsReport);
        }
    }
}
