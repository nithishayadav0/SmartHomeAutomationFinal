using SmartHomeAutomation.Models;
using SmartHomeAutomation.Data; // Your DbContext namespace
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartHomeAutomation.Repositories
{
    
    public class GlobalAutomationRepository : IGlobalAutomationRepository
    {
        private readonly SmartHomeDbContext _context;

        public GlobalAutomationRepository(SmartHomeDbContext context)
        {
            _context = context;
        }

         //GEtting All Global Automations Which are set by Administrator
        public async Task<IEnumerable<GlobalAutomation>> GetAllAutomationsAsync()
        {
            return await _context.GlobalAutomations.ToListAsync();
         
        }

        public async Task AddAutomationAsync(GlobalAutomation automation)
        {
            await _context.GlobalAutomations.AddAsync(automation);
            await _context.SaveChangesAsync();
        }

    }
}
