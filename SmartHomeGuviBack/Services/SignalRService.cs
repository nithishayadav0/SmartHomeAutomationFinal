using Microsoft.AspNetCore.SignalR;
using SmartHomeAutomation.SignalR;

namespace SmartHomeAutomation.Services
{
    public class SignalRService
    {
        private readonly IHubContext<AlertHub> _hubContext;

        public SignalRService(IHubContext<AlertHub> hubContext)
        {
            _hubContext = hubContext;
        }

        // Method to send alerts to connected clients
        public async Task SendAlertToFrontend(string message)
        {
            Console.WriteLine("accessing");
            // Send the message to all connected clients
            await _hubContext.Clients.All.SendAsync("ReceiveAlert", message);
        }
    }
}
