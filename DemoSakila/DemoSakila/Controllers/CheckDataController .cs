using DemoSakila.API.Realtime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace DemoSakila.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckDataController : ControllerBase
    {
        private readonly IHubContext<ActivityHub> _hub;
        private readonly TimerManager _timer;

        public CheckDataController(IHubContext<ActivityHub> hub, TimerManager timer)
        {
            _hub = hub;
            _timer = timer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!_timer.IsTimerStarted)
                _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("check_data", ActivityManager.GetListActivities()));

            return Ok(new { Message = "Request Completed" });
        }

        [HttpGet("sse")]
        public async Task SSE()
        {
            //Response.Headers.Add("Content-Type", "text/event-stream");
            //Response.Headers.Add("Cache-Control", "no-cache");

            //var stream = Response.Body;
            //var lastActivities = ActivityManager.GetListActivities().Last(); // Lấy danh sách hoạt động gần đây

            //await stream.WriteAsync(Encoding.UTF8.GetBytes(lastActivities));
            //await stream.FlushAsync();
            ////await Task.Delay(5000);
            //HttpContext.Response.Headers.Add("Content-Type", "text/event-stream");
            //HttpContext.Response.Headers.Add("Cache-Control", "no-cache");
            //HttpContext.Response.Headers.Add("Connection", "keep-alive");

            //for (int i = 0; i < 10; i++)
            //{
            //    Response.WriteAsync($"data: Message {i}\n\n");
            //    Response.Body.Flush();
            //    Thread.Sleep(1000); // Simulate sending data every second
            //}

            //return new EmptyResult();

            HttpContext.Response.Headers.Add("Content-Type", "text/event-stream");
            HttpContext.Response.Headers.Add("Cache-Control", "no-cache");
            HttpContext.Response.Headers.Add("Connection", "keep-alive");

            var lastActivityCount = -1;

            var listSend = new List<string?>();

            while (true)
            {
                if (ActivityManager.LastActivities.Any())
                {
                    var lastActivity = ActivityManager.LastActivities.Last();

                    if (!listSend.Contains(lastActivity))
                    {
                        listSend.Add(lastActivity);
                        await Response.WriteAsync(lastActivity);
                        Response.Body.Flush();
                    }
                    Thread.Sleep(1000);
                }
            }
        }


        [HttpGet("polling")]
        public List<string> PollingAsync()
        {
            return ActivityManager.GetListActivities();
        }


        [HttpGet("long-polling")]
        public async Task<List<string>> LongPolling()
        {
            var data = await GetNewData();
            return data;
        }

        private async Task<List<string>> GetNewData()
        {
            using (var cts = new CancellationTokenSource())
            {
                var result = await Task.WhenAny(Task.Delay(5000, cts.Token), FetchingDataLogic());
                cts.Cancel();
                return await Task.FromResult(ActivityManager.GetListActivities());
            }
        }

        private async Task<object> FetchingDataLogic()
        {
            return await Task.FromResult(ActivityManager.GetListActivities());
        }

        [HttpGet("add-activity")]
        public void AddActivity(string activity)
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var username = identity?.FindFirst("UserName")?.Value;
                if (!string.IsNullOrWhiteSpace(username))
                {
                    ActivityManager.AddActivity(activity + DateTime.Now.ToString());
                }
            }
        }

        [HttpGet("clear")]
        public void Clear()
        {
            ActivityManager.Clear();

            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var username = identity?.FindFirst("UserName")?.Value;
                if (!string.IsNullOrWhiteSpace(username))
                {
                    ActivityManager.AddActivity(username + " - " + " clear list" + DateTime.Now.ToString());
                }
            }
        }
    }
}
