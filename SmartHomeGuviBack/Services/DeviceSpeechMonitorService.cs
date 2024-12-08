using System;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;



namespace SmartHomeAutomation.Services
{
    public class DeviceSpeechMonitorService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;
        private readonly SpeechSynthesizer _speechSynthesizer;

        public DeviceSpeechMonitorService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _speechSynthesizer = new SpeechSynthesizer();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Ensure the timer runs periodically with the correct interval
            _timer = new Timer(CheckDevices, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private void CheckDevices(object state)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<SmartHomeDbContext>();
                var currentTime = DateTime.Now;

                // Check for AC devices that are "On"
                var acDevices = _context.Devices
                    .Where(d => d.Name.ToLower() == "ac" && d.Status.ToLower() == "on")
                    .ToList();
                Console.WriteLine("Enetered to speech");
                foreach (var device in acDevices)
                {
                    // If the AC has been on for more than 2 minutes, trigger the speech alert
                    if ((currentTime - device.LastUpdated).TotalMinutes > 2)
                    {
                        Console.WriteLine("Entering here");
                        TriggerSpeechAlert(device, "Your AC has been running for more than 2 minutes.");
                    }
                }

                // Check for LPG leakage devices
                var lpgLeakageDevices = _context.Devices
                    .Where(d => d.Name.ToLower() == "lpg gas" && d.Status.ToLower() == "leakage detected")
                    .ToList();

                foreach (var device in lpgLeakageDevices)
                {
                    // Trigger the speech alert for LPG leakage
                    TriggerSpeechAlert(device, "LPG leakage detected. Please take immediate action!");
                }
            }
        }

        private void TriggerSpeechAlert(Device device, string alertMessage)
        {
            // Speak the alert message
            Speak(alertMessage);
        }

        private void Speak(string message)
        {
            _speechSynthesizer.SpeakAsync(message);
            Console.WriteLine($"Voice Alert: {message}");
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
