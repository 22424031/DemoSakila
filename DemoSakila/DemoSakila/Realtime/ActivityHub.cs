using Microsoft.AspNetCore.SignalR;

namespace DemoSakila.API.Realtime
{
    public class ActivityHub : Hub
    {
        public async Task MyBroadcast(BroadCastModel data) =>
            await Clients.All.SendAsync("mybroadcast", data);
    }

    public class BroadCastModel
    {
        public string Activity { get; set; } = string.Empty;
    }
}
