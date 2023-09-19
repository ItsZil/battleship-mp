using Microsoft.AspNetCore.SignalR;

namespace ServerApp
{
    public class GameHub : Hub
    {        
        public async void Hello()
        {

        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("TestMessage", Context.ConnectionId);
            
            await base.OnConnectedAsync();
        }
    }
}
