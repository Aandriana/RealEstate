using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace RealEstate.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public ChatHub()
        {

        }

        public override async Task OnConnectedAsync()
        {
            var tmp = Context.User;
            var tlp = Clients.All;
            await base.OnConnectedAsync();
        }
    }
}
