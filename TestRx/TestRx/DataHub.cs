using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRx
{
    public class DataHub : Hub
    {
        public async Task Start(string clientId)
        {
            await Clients.All.SendAsync("Start", clientId);
        }

        public async Task Complete(string clientId, string count)
        {
            await Clients.All.SendAsync("Complete", clientId, count);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
