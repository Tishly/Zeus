using Microsoft.AspNetCore.SignalR;

namespace ZeusChatServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task JoinChat(string user)
        {
            //Notify all other clients that a user has joined the chat
            await Clients.Others.SendAsync("UserJoined", user);
        }
        public async Task SendPrivateMessage(string toUser, string message)
        {
            await Clients.User(toUser).SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
        }   
    }
}
