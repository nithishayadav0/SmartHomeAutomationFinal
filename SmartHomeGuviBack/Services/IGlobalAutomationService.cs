using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Services
{
    public interface IGlobalAutomationService
    {
        Task<IEnumerable<GlobalAutomation>> GetAllAutomationsAsync();
       
        Task AddAutomationAsync(GlobalAutomation automation);
    }
}
