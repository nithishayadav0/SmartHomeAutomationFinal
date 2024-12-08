using System;
using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartHomeAutomation.Repositories
{
    public class SettingRepository: ISettingRepository
    {
        private readonly SmartHomeDbContext _dbContext;

        public SettingRepository(SmartHomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get settings from the database
        public async Task<Settings> GetSettingsAsync()
        {
            return await _dbContext.Settings.FirstOrDefaultAsync();
        }

        // Update settings in the database
        public async Task UpdateSettingsAsync(Settings settings)
        {
            _dbContext.Settings.Update(settings);
            await _dbContext.SaveChangesAsync();
        }
    }
}
