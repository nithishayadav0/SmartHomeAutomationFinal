using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartHomeAutomation.Models;
using SmartHomeAutomation.Data;
using SmartHomeAutomation.Repositories;

namespace SmartHomeAutomation.Services
{
    public class AutomationService : IAutomationService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IAutomationRepository _repository;
        private readonly DeviceRepository _deviceRepository;

        private Timer _timer;

        public AutomationService(IServiceScopeFactory serviceScopeFactory, IAutomationRepository repository, DeviceRepository deviceRepository)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _repository = repository;
            _deviceRepository = deviceRepository;
        }



        public async Task<IEnumerable<Automation>> GetAutomationsByUserIdAsync(int userId)
        {
            return await _repository.GetAutomationsByUserIdAsync(userId);
        }
        
        public async Task<bool> CheckDeviceExistsAsync(int deviceId)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(deviceId);
            return device != null;
        }

        public async Task<Automation> CreateAutomationAsync(Automation automation)
        {
            // Validate or modify the automation here, if necessary
            return await _repository.AddAutomationAsync(automation);
        }


        public async Task<bool> DeleteAutomationAsync(int id)
        {
            var automation = await _repository.GetAutomationByIdAsync(id);
            if (automation == null)
            {
                return false; // Automation not found
            }

            await _repository.DeleteAutomationAsync(id);
            return true; // Automation deleted successfully
        }


    }

  

}
