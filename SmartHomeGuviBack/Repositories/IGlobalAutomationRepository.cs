using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public interface IGlobalAutomationRepository
    {
        Task AddAutomationAsync(GlobalAutomation automation);
        Task<IEnumerable<GlobalAutomation>> GetAllAutomationsAsync();
    }
}
