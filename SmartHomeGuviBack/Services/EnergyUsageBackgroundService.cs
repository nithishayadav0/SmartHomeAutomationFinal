
namespace SmartHomeAutomation.Services
{
    public class EnergyUsageBackgroundService: IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly EnergyUsageService _energyMonitoringService;

        public EnergyUsageBackgroundService(EnergyUsageService energyMonitoringService)
        {
            _energyMonitoringService = energyMonitoringService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(_energyMonitoringService.CheckEnergyUsage, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}
