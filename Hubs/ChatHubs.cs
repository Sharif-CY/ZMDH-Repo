using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WDPR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }

        [Authorize("Moderator")]
        public void BanUser(string userName)
        {
        }
        
        [Authorize("Moderator")]
        public void MuteUser(string userName)
        {
            
        }

        [Authorize("Moderator")]
        public void DeleteMessage(string message)
        {
            
        }
    }
}