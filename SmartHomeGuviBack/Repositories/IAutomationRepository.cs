using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public interface IAutomationRepository
    {
        Task<IEnumerable<Automation>> GetAutomationsByUserIdAsync(int userId);
    
        Task<Automation> AddAutomationAsync(Automation automation);
        Task<Automation> GetAutomationByIdAsync(int id);
        Task<bool> DeleteAutomationAsync(int id);
    }
}
