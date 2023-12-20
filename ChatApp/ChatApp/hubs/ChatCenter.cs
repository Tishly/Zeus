using Microsoft.AspNetCore.SignalR;

namespace ChatApp.hubs
{
    public class ChatCenter : Hub 
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinChat(string user, string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", user, message);
        }
    }
}
