using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Server
{
    public class ChatHub : Hub
    {
        public async Task AllMessage_Send(string user, string message)
        {
            var content = $"{user} ({DateTime.Now.ToShortTimeString()})：{message}";

            await Clients.All.SendAsync("AllMessage_Recevie", content);
        }
    }
}