using Microsoft.AspNetCore.SignalR;

namespace ZeusBackend.Hubs
{
    public class ChatHub : Hub
    {

        // This method will send notifications to all clients
        // If client have to communicate, it will call <SendMessage()> method
        // If client have to receive notification from server server it will use.
        // <receiveMessage> method.
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
