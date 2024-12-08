using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;


using Microsoft.EntityFrameworkCore;
namespace SmartHomeAutomation.Services
{
    public class EnergyMonthlyUsageService
    {
        private readonly SmartHomeDbContext _context;
        public EnergyMonthlyUsageService(SmartHomeDbContext context)
        {
            _context = context;
        }
        public async Task<List<MonthlyEnergyReport>> GetMonthlyEnergyReportByUserEmail(string userEmail)
        {
            // LINQ query to get monthly energy consumption and cost
            var report = await (from e in _context.EnergyUsages
                                join d in _context.Devices on e.DeviceId equals d.DeviceId
                                join r in _context.Rooms on d.RoomId equals r.RoomId
                                join u in _context.Users on r.UserId equals u.UserId
                                where u.Email == userEmail
                                group e by new { Year = e.TimePeriod.Year, Month = e.TimePeriod.Month } into g
                                select new MonthlyEnergyReport
                                {
                                    Year = g.Key.Year,
                                    Month = g.Key.Month,
                                    TotalConsumption = g.Sum(x => x.Consumption),
                                    TotalCost = g.Sum(x => x.EnergyCost)
                                }).ToListAsync();

            return report;
        }
    }
}
