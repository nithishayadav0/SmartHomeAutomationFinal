using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SmartHomeAutomation.SignalR
{
    public class AlertHub : Hub
    {
        // Sends an alert message to all connected clients
        public async Task SendAlert(string message)
        {
            await Clients.All.SendAsync("ReceiveAlert", message);
        }
    }
}
