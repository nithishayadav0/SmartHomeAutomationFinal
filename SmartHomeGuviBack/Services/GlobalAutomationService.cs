using SmartHomeAutomation.Models;
using SmartHomeAutomation.Repositories;

namespace SmartHomeAutomation.Services
{
    public class GlobalAutomationService : IGlobalAutomationService
    {
        private readonly IGlobalAutomationRepository _repository;

        public GlobalAutomationService(IGlobalAutomationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GlobalAutomation>> GetAllAutomationsAsync()
        {
            return await _repository.GetAllAutomationsAsync();
        }

    

        public async Task AddAutomationAsync(GlobalAutomation automation)
        {
            await _repository.AddAutomationAsync(automation);
          
        }
     

    }
}
