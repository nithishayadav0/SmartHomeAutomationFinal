using SmartHomeAutomation.Models;
using SmartHomeAutomation.Repositories;

namespace SmartHomeAutomation.Services
{
    public class SecurityService:ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;

        public SecurityService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        public async Task UpdateStatusAsync(string status)
        {
            await _securityRepository.UpdateStatusAsync(status);
        }
        public async Task<List<SecurityDevice>> GetAllSecurityDevicesAsync()
        {
            return await _securityRepository.GetAllSecurityDevicesAsync();
        }
        public async Task<IEnumerable<string>> GetCurrentDetectionsAsync()
        {
            var currentTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            var devices = await _securityRepository.GetAllSecurityDevicesAsync();
            var currentDetections = new List<string>();

            foreach (var device in devices)
            {
                if (!string.IsNullOrEmpty(device.DetectionHistory))
                {
                    var events = device.DetectionHistory.Split('|', StringSplitOptions.TrimEntries);

                    foreach (var evt in events)
                    {
                        if (evt.Contains(currentTime))
                        {
                            currentDetections.Add($"[{device.Type} in {device.Location}] {evt.Trim()}");
                        }
                    }
                }
            }

            return currentDetections;
        }
    }
}
