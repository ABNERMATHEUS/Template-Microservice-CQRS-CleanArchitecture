
using Microsoft.AspNetCore.SignalR;
namespace TemplateMicroservice.Api.Hubs;


    public class NotificationHub : Hub
    {
        public async Task NewMessage(long username, string message) =>
            await Clients.All.SendAsync("messageReceived", username, message);
    
    }

